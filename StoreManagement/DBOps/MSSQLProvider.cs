using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Net;
using StoreManagement.Properties;
using StoreManagement.Model;

namespace StoreManagement
{
    public class MSSQLProvider : IDBProvider
    {
        public MSSQLProvider()
        {
            return;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DataSource { get; set; }
        public DBType Type { get; set; }
        public string ABName { get; set; }
        public string DBName { get; set; }
        public ConnectionState State { get { return conn.State; } }
        private SqlConnection conn = new SqlConnection();
        private SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        private string ConnectionString
        {
            get
            {
                IPEndPoint ep = Utility.SvrSocket.RemoteEndPoint as IPEndPoint;
                builder.DataSource = ep.Address.ToString();
                builder.UserID = Username;
                builder.Password = string.IsNullOrEmpty(Password) == true ? string.Empty : Password;
                builder.ConnectTimeout = 20;
                builder.InitialCatalog = "master";
                return builder.ConnectionString;
            }
        }

        public void SetConnectionBuilder(IPEndPoint host, string name, string pwd)
        {
            builder.DataSource = host.Address.ToString();
            builder.UserID = name;
            builder.Password = string.IsNullOrEmpty(pwd) == true ? string.Empty : pwd;
            builder.ConnectTimeout = 20;
            //builder.TrustServerCertificate = false;
        }

        private string GetConnectionString(string datasource)
        {
            builder.InitialCatalog = datasource;
            return builder.ConnectionString;
        }

        public void Dispose()
        {
            DisConnect();
        }

        public bool TestConnect()
        {
            bool ret = true;
            using (SqlConnection conn = new SqlConnection(GetConnectionString("master")))
            {
                try
                {
                    conn.Open();
                    ret = true;
                }
                catch (InvalidOperationException opExp)
                {
                    Utility.LastErrorMessage = opExp.Message;
                    ret = false;
                }
                catch (SqlException sqlExp)
                {
                    Utility.LastErrorMessage = sqlExp.Message;
                    ret = false;
                }
            }
            return ret;
        }

        public bool Connect()
        {
            conn.ConnectionString = ConnectionString;
            try
            {
                conn.Open();
            }
            catch (InvalidOperationException opExp)
            {
                Utility.LastErrorMessage = opExp.Message;
                return false;
            }
            catch (SqlException sqlExp)
            {
                Utility.LastErrorMessage = sqlExp.Message;
                return false;
            }
            return true;
        }
        public bool DisConnect()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            else if (conn.State != ConnectionState.Closed)
            {
                Utility.LastErrorMessage = "数据库连接正在执行中，请稍后重试断开连接";
                return false;
            }
            return true;
        }

        private bool LoadReaderIntoDataTable(SqlDataReader reader, DataTable table)
        {
            bool ret = true;
            DataTable schemaTable = reader.GetSchemaTable();
            try
            {
                foreach (DataRow row in schemaTable.Rows)
                { 
                    
                }
            }
            catch (Exception anyExp)
            {
                Utility.LastErrorMessage = anyExp.Message;
                ret = false;
            }
            return ret;
        }

        // 获取账本
        public bool GetAB(DataTable dt)
        {
            bool ret = false;
            using (SqlConnection conn = new SqlConnection(GetConnectionString(Settings.Default.MSSQLSYSDB)))
            {
                conn.Open();
                string ChkLMTableStatement = string.Format("select count(*) from {0}.{1} where xtype='U' and object_id(N'{2}')=id",
                                                Settings.Default.MSSQLSYSDB, Settings.Default.MSSQLSYSTABLE, Settings.Default.LMTABLE);

                try
                {
                    // 判断主表是否建立，没有则创建
                    SqlCommand cmd = new SqlCommand(ChkLMTableStatement, conn);
                    int iNum = (int)cmd.ExecuteScalar();
                    if (iNum == 0)
                    { 
                        // 开始事务
                        SqlTransaction trans = conn.BeginTransaction();
                        cmd.Transaction = trans;
                        try
                        {
                            // 创建主表
//                            string CrtLMTableStatement = string.Format(@"create table dbo.{0} (
//                                                                    id int IDENTITY(1,1) PRIMARY KEY,
//                                                                    ABName nvarchar(20) unique not null,
//                                                                    DBName nvarchar(20) unique not null,
//                                                                    CrtDate datetime not null 
//                                                                    )", Settings.Default.LMTABLE);
//                            cmd.CommandText = CrtLMTableStatement;
//                            iNum = cmd.ExecuteNonQuery();
                            // 导入TSQL脚本
                            string[] sqls = Utility.RetrieveSQLStatement(Settings.Default.LMSPFile);
                            //if (sqls == null)
                            //{
                            //    string DelLMTableStatement = string.Format("drop table dbo.{0}", Settings.Default.LMTABLE);
                            //    cmd.CommandText = DelLMTableStatement;
                            //    cmd.ExecuteNonQuery();
                            //    return false;
                            //}
                            foreach (string statement in sqls)
                            {
                                cmd.CommandText = statement;
                                cmd.ExecuteNonQuery();
                            }
                            trans.Commit();
                        }
                        catch (SqlException sqlExp)
                        {
                            trans.Rollback();
                            Utility.LastErrorMessage = sqlExp.Message;
                            return false;
                        }
                    }

                    cmd.CommandText = "GETAB";
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.ExecuteNonQuery();



                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //da.Fill(dt);
                    SqlDataReader  da = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dt.Columns.Clear();
                    dt.Rows.Clear();
                    dt.Columns.Add("编号", typeof(Int32));
                    dt.Columns.Add("账本", typeof(string));
                    dt.Columns.Add("数据库", typeof(string));
                    dt.Columns.Add("创建时间", typeof(DateTime));
                    while (da.Read())
                    {

                        object[] vals = new object[da.FieldCount];
                        da.GetValues(vals);
                        dt.Rows.Add(vals);
                        
                    }
                    ret = true;
                }
                catch (SqlException sqlExp)
                {
                    Utility.LastErrorMessage = sqlExp.Message;
                    ret = false;
                }
                catch (InvalidOperationException opExp)
                {
                    Utility.LastErrorMessage = opExp.Message;
                    ret = false;
                }
                finally
                {

                }
            }
            return ret;
        }

        // 创建账本
        public bool AddAB(string strABName, string strDBName)
        { 
            bool ret = true;
            if (string.IsNullOrEmpty(strABName) == true ||
                string.IsNullOrEmpty(strDBName) == true)
            {
                Utility.LastErrorMessage = "非法输入参数";
                return false;
            }
            try
            {
                //using (TransactionScope scope = new TransactionScope())
                //{
                    // 创建账本数据库
                using (SqlConnection conn = new SqlConnection(GetConnectionString(Settings.Default.MSSQLSYSDB)))
                    {
                        
                        conn.Open();
                        string AddDBStatement = string.Format("create database {0}", strDBName);
                        SqlCommand cmd = new SqlCommand(AddDBStatement, conn);
                        cmd.CommandTimeout = 120;
                        cmd.ExecuteNonQuery();
                        //if (0 == cmd.ExecuteNonQuery())
                        {
                            using (SqlConnection conn1 = new SqlConnection(GetConnectionString(strDBName)))
                            {
                                string curstring = null;
                                conn.ChangeDatabase(strDBName);
                                SqlTransaction trans = conn.BeginTransaction();
                                try
                                {

                                    SqlCommand cmd1 = new SqlCommand();
                                    cmd1.Connection = conn;
                                    cmd1.Transaction = trans;
                                    cmd1.CommandTimeout = 120;

                                    string[] sqls = Utility.RetrieveSQLStatement(Settings.Default.ABSPFile);

                                    foreach (string strsql in sqls)
                                    {
                                        curstring = strsql;
                                        cmd1.CommandText = strsql;
                                        cmd1.ExecuteNonQuery();
                                    }

                                    trans.Commit();
                                }
                                catch (SqlException sqlExp)
                                {
                                    trans.Rollback();
                                    Utility.LastErrorMessage = sqlExp.Message;
                                    ret = false;
                                }
                                catch (Exception anyExp)
                                {
                                    trans.Rollback();
                                    Utility.LastErrorMessage = anyExp.Message;
                                    ret = false;
                                }
                            }

                            if (ret == true)
                            {
                                conn.ChangeDatabase(Settings.Default.MSSQLSYSDB);
                                cmd.CommandText = "ADDAB";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@AB", SqlDbType.NVarChar, 20);
                                cmd.Parameters.Add("@DB", SqlDbType.NVarChar, 20);
                                cmd.Parameters["@AB"].Value = strABName;
                                cmd.Parameters["@DB"].Value = strDBName;
                                int num = cmd.ExecuteNonQuery();
                                if (num == 0)
                                    ret = false;
                            }

                        }
                        if (ret == false)
                        {
                            cmd.CommandText = string.Format("DROP DATABASE {0}", strDBName);
                            cmd.ExecuteNonQuery();
                        }
                    }
            }
            catch (SqlException sqlExp)
            {
                Utility.LastErrorMessage = sqlExp.Message;
                ret = false;
            }
            catch (InvalidOperationException opExp)
            {
                Utility.LastErrorMessage = opExp.Message;
                ret = false;
            }
            return ret;
        }

        // 删除账本
        public bool DelAB(int id, string strDBName)
        {
            bool ret = false;
            using (SqlConnection conn = new SqlConnection(GetConnectionString(Settings.Default.MSSQLSYSDB)))
            {
                conn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 120;


                    cmd.CommandText = "DELAB";
                    cmd.CommandType = CommandType.StoredProcedure;                    

                    cmd.Parameters.Add("@ID", SqlDbType.Int);
                    cmd.Parameters["@ID"].Value = id;
                    cmd.Parameters.Add(new SqlParameter("@RET", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "RET", DataRowVersion.Default, null));

                    cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    cmd.ExecuteNonQuery();

                    int iret = (int)cmd.Parameters["@RET"].Value;
                    if (iret > 0)
                    {
                        ret = true;
                    }
                    else
                    {
                        ret = false;
                    }
                }
                catch (SqlException sqlExp)
                {
                    Utility.LastErrorMessage = sqlExp.Message;
                    ret = false;
                }
                catch (InvalidOperationException opExp)
                {
                    Utility.LastErrorMessage = opExp.Message;
                    ret = false;
                }
                catch (Exception anyExp)
                {
                    Utility.LastErrorMessage = anyExp.Message;
                    ret = false;
                }
            }
            return ret;
        }

        // 判断是否是账本用户
        public bool IsUser(string strDBName, string username, string password)
        {
            bool ret = true;
            using (SqlConnection conn = new SqlConnection(GetConnectionString(strDBName)))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ISUSER";

                    cmd.Parameters.Add("@USERNAME", SqlDbType.NVarChar, 20);
                    cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar, 32);
                    cmd.Parameters.Add(new SqlParameter("@RET", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Default, null));
                    cmd.Parameters["@USERNAME"].Value = username;
                    cmd.Parameters["@PASSWORD"].Value = Utility.GetMD5(password);
                    cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;

                    cmd.ExecuteNonQuery();

                    if (DBNull.Value.Equals(cmd.Parameters["@RET"].Value) == false)
                    {
                        LoginUser.CurrentUser.UserID = (int)cmd.Parameters["@RET"].Value;
                        LoginUser.CurrentUser.UserName = username;
                        LoginUser.CurrentUser.UserPwd = password;
                        LoginUser.CurrentUser.Available = true;
                        ret = true;
                    }
                    else
                    {
                        //LoginUser.CurrentUser.Available = false;
                        Utility.LastErrorMessage = Settings.Default.UsernamePasswordInputError;
                        ret = false;
                    }

                    conn.Close();
                }
                catch (SqlException sqlExp)
                {
                    Utility.LastErrorMessage = sqlExp.Message;
                    ret = false;
                }
            }
            return ret;
        }

        // 修改账本用户密码
        public bool ChangePwd(string strDBName, int userId, string newPwd)
        { 
            bool ret = true;
            using (SqlConnection conn = new SqlConnection(GetConnectionString(strDBName)))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("CHANGEPWD", conn);
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ID", SqlDbType.Int);
                    cmd.Parameters.Add("@PWD", SqlDbType.VarChar, 32);
                    cmd.Parameters.Add(new SqlParameter("@RET", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Default, null));
                    cmd.Parameters["@ID"].Value = userId;
                    cmd.Parameters["@PWD"].Value = Utility.GetMD5(newPwd);

                    int numeff = cmd.ExecuteNonQuery();
                    
                    if (DBNull.Value.Equals(cmd.Parameters["@RET"].Value) != true && numeff > 0)
                    {
                        int iret = (int)cmd.Parameters["@RET"].Value;
                        if (iret == 1)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                    }
                    else
                    {
                        ret = false;
                    }

                    conn.Close();
                    
                }
                catch (SqlException sqlExp)
                {
                    Utility.LastErrorMessage = sqlExp.Message;
                    ret = false;
                }
                catch (Exception anyExp)
                {
                    Utility.LastErrorMessage = anyExp.Message;
                    ret = false;
                }
            }
            return ret;
        }

        // 获取指定商品分类列表
        public bool GetGoodsFolder(string strDBName, int folderId, Dictionary<int, string> folders)
        { 
            bool ret = false;
            folders.Clear();
            using (SqlConnection conn = new SqlConnection(GetConnectionString(strDBName)))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("FN_HASGOODSFOLDER_BY_ID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.Int);
                    cmd.Parameters["@ID"].Value = folderId;
                    cmd.Parameters.Add("@return", SqlDbType.Int);
                    cmd.Parameters["@return"].Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    int exeret = (int)cmd.Parameters["@return"].Value;
                    if (exeret == 0)
                    {
                        Utility.LastErrorMessage = "无效的文件名";
                    }
                    else
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "SP_GETGOODSFOLDER_BY_FLD_ID";
                        cmd.Parameters.Add("@FLD_ID", SqlDbType.Int);
                        cmd.Parameters["@FLD_ID"].Value = folderId;
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (dr.Read())
                        {
                            folders.Add((int)dr[0], (string)dr[1]);
                        }
                        ret = true;
                    }
                }
                catch (SqlException sqlExp)
                {
                    Utility.LastErrorMessage = sqlExp.Message;
                }
            }
            return ret;
        }

        // 获取所有商品分类列表
        public bool GetAllGoodsFolder(string strDBName, Dictionary<int, Folder> Folders)
        {
            bool ret = false;
            Folders.Clear();
            using (SqlConnection conn = new SqlConnection(GetConnectionString(strDBName)))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SP_GETALLGOODSFOLDER", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (Folders.ContainsKey((int)dr["GOODS_FLD_ID"]) == false)
                        {
                            Folder folder = new Folder();
                            folder.ID = (int)dr["GOODS_FLD_ID"];
                            folder.ParentID = (int)dr["GOODS_FLD_PARENT_ID"];
                            folder.Name = (string)dr["GOODS_FLD_NAME"];
                            folder.Childs = new HashSet<int>();
                            Folders.Add(folder.ID, folder);
                        }
                        else
                        {
                            Utility.WriteLog(ELogType.Warning, string.Format("商品分类ID重复: {0}={1}", (string)dr["GOODS_FLD_NAME"], Folders[(int)dr["GOODS_FLD_ID"]].Name));
                        }
                    }
                    ret = true;
                }
                catch (SqlException sqlExp)
                {
                    Utility.LastErrorMessage = sqlExp.Message;
                }
            }
            return ret;
        }

        // 创建商品分类名称
        public bool AddFolder(string strDBName, int parentId, string name, out int id)
        {
            bool ret = false;
            id = -1;
            using (SqlConnection conn = new SqlConnection(GetConnectionString(strDBName)))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_ADDGOODSFOLDER", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 120;
                    cmd.Parameters.Add("@FLD_NAME", SqlDbType.NVarChar, 50);
                    cmd.Parameters.Add("@PARENT_ID", SqlDbType.Int);
                    cmd.Parameters.Add("@ret", SqlDbType.Int);
                    cmd.Parameters["@FLD_NAME"].Value = name;
                    cmd.Parameters["@PARENT_ID"].Value = parentId;
                    cmd.Parameters["@ret"].Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    int iret = (int)cmd.Parameters["@ret"].Value;
                    if (iret == -1)
                    {
                        Utility.LastErrorMessage = Settings.Default.FolderSettingParentIdInexistenceErrorMessage;
                    }
                    else if (iret == -2)
                    {
                        Utility.LastErrorMessage = Settings.Default.FolderSettingSameFolderErrorMessage;
                    }
                    else
                    {
                        id = (int)cmd.Parameters["@ret"].Value;
                        ret = true;
                    }
                }
                catch (SqlException sqlExp)
                {
                    Utility.LastErrorMessage = sqlExp.Message;
                }
            }
            return ret;
        }

        // 修改商品分类名称
        public bool ModifyFolder(string strDBName, int id, string name)
        {
            bool ret = false;
            using (SqlConnection conn = new SqlConnection(GetConnectionString(strDBName)))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_MODIFYGOODSFOLDER", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 120;
                    cmd.Parameters.Add("@ID", SqlDbType.Int);
                    cmd.Parameters.Add("@FLD_NAME", SqlDbType.NVarChar, 50);
                    cmd.Parameters.Add("@ret", SqlDbType.Int);
                    cmd.Parameters["@ID"].Value = id;
                    cmd.Parameters["@FLD_NAME"].Value = name;
                    cmd.Parameters["@ret"].Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    int iret = (int)cmd.Parameters["@ret"].Value;
                    if (iret == -1)
                    {
                        Utility.LastErrorMessage = Settings.Default.FolderSettingParentIdInexistenceErrorMessage;
                    }
                    else if (iret == -2)
                    {
                        Utility.LastErrorMessage = Settings.Default.FolderSettingSameFolderErrorMessage;
                    }
                    else
                    {
                        ret = true;
                    }
                }
                catch (SqlException sqlExp)
                {
                    Utility.LastErrorMessage = sqlExp.Message;
                }
            }
            return ret;
        }

        // 删除商品分类
        public bool DeleteFolder(string strDBName, int id)
        {
            bool ret = false;
            using (SqlConnection conn = new SqlConnection(GetConnectionString(strDBName)))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SP_DELETEGOODSFOLDER", conn);
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.Int);
                    cmd.Parameters.Add("@RET", SqlDbType.Int);
                    cmd.Parameters["@ID"].Value = id;
                    cmd.Parameters["@RET"].Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    int iret = (int)cmd.Parameters["@RET"].Value;
                    switch (iret)
                    { 
                        case -1:
                            Utility.LastErrorMessage = "无效商品分类";
                            break;
                        case -2:
                            Utility.LastErrorMessage = "存在商品子分类";
                            break;
                        case 0:
                            ret = true;
                            break;
                    }
                }
                catch (SqlException sqlExp)
                {
                    Utility.LastErrorMessage = sqlExp.Message;
                }
            }
            return ret;
        }

        // 返回所有条形码格式
        public bool GetBarCodeFormat(string strDBName, Dictionary<int, string> fmts)
        { 
            bool ret = false;
            using (SqlConnection conn = new SqlConnection(GetConnectionString(strDBName)))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SP_GETBARCODEFMT", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 120;
                    
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    fmts.Clear();
                    while (dr.Read())
                    {
                        int id = dr.GetInt32(0);
                        string value = (string)dr["BARCODEFMT_NAME"];
                        if (fmts.ContainsKey(id) == false)
                            fmts.Add(id, value);
                        else
                            fmts[id] = value;
                    }
                    ret = true;
                }
                catch (SqlException sqlExp)
                {
                    Utility.LastErrorMessage = sqlExp.Message;
                }
            }
            return ret;
        }

        // 获取所有颜色
        public bool GetAllColor(string strDBName, DataTable dt)
        {
            bool ret = true;
            using (SqlConnection conn = new SqlConnection(GetConnectionString(strDBName)))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_GETCOLOR", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 120;

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Clear();
                dt.Columns.Add("Key", typeof(int));
                dt.Columns.Add("Value", typeof(string));
                
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string value = (string)dr.GetValue(1);
                    //if (colors.ContainsKey(id) == false)
                    //    colors.Add(id, value);
                    //else
                    //    colors[id] = value;
                    dt.Rows.Add(id, value);
                }
            }
            return ret;
        }

        // 获取所有尺寸
        public bool GetSelectedSize(string strDBName, Int32 goodsId, List<int> selectedSizeIds)
        {
            // TODO
            return false;
        }

        // 获取商品信息
        public bool GetGoodsInfo(string strDBName, Int64 goodsId, ref GoodsInfo goodsInfo)
        {
            bool ret = false;
            using (SqlConnection conn = new SqlConnection(GetConnectionString(strDBName)))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_GETGOODSINFOBYGOODSID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 60;

                    cmd.Parameters.Add("@GOODSID", SqlDbType.BigInt);
                    cmd.Parameters["@GOODSID"].Value = goodsId;

                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (dr.HasRows == false)
                    {
                        Utility.LastErrorMessage = "Not Found any result to specified goodsid";
                    }
                    else
                    {
                        while (dr.Read())
                        {
                            
                        }
                        ret = true;
                    }
                }
                catch (Exception exp)
                {
                    
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
            return ret;
        }
    }
}
