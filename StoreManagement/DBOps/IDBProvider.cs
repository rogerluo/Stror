using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;
using System.Data.Sql;


namespace StoreManagement
{
    public enum DBType
    {
        MYSQL,
        MSSQL,
        ORACLE,
    }
    //abstract public class IDBProvider
    //{
    //    public string Username { get; set; }
    //    public string Password { get; set; }
    //    public DBType Type { get; set; }
    //    abstract public bool Connect();
    //}
    public interface IDBProvider : IDisposable
    {
        string Username { get; set; }
        string Password { get; set; }
        string DataSource { get; set; }
        string DBName { get; set; }
        string ABName { get; set; }
        DBType Type { get; set; }
        ConnectionState State { get;}
        void SetConnectionBuilder(IPEndPoint host, string name, string pwd);
        bool Connect();
        bool DisConnect();
        bool GetAB(DataTable datas);
        bool AddAB(string strABName, string strDBName);
        bool DelAB(int id, string dbname);
        
        // 账本单独函数
        bool IsUser(string strDBName, string username, string password);
        bool ChangePwd(string strDBName, int userId, string newPwd);
        bool GetGoodsFolder(string strDBName, int folderId, Dictionary<int, string> folders);
        bool GetAllGoodsFolder(string strDBName, Dictionary<int, Folder> Folders);
        bool AddFolder(string strDBName, int parentId, string name, out int id);
        bool ModifyFolder(string strDBName, int id, string name);
        bool DeleteFolder(string strDBName, int id);
        bool GetBarCodeFormat(string strDBName, Dictionary<int, string> fmts);
        bool GetAllColor(string strDBName, DataTable dt);
        bool GetSelectedSize(string strDBName, Int32 goodsId, List<int> selectedSizeIds);
    }
}
