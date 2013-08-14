using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using StoreManagement.Properties;

namespace StoreManagement
{
    public enum SQLStatementType
    {
        EXISTSLM,
        CREATELM,
        SELECTLM,
        INSERTLM,
        DELETELM,

        CREATEAB,
        SELECTAB,
        INSERTAB,
        DELETEAB,
    }

    public class DBFactory
    {
        static public IDBProvider InitProvider(DBType type, IPEndPoint ep, string user, string pwd, object other)
        {
            IDBProvider provider = null;
            switch (type)
            {
                case DBType.MSSQL:
                    {
                        provider = new MSSQLProvider();
                        provider.Username = user;
                        provider.Password = pwd;
                        provider.SetConnectionBuilder(ep, user, pwd);
                    }
                    break;
                case DBType.MYSQL:
                    {
                        
                    }
                    break;
                case DBType.ORACLE:
                    { 
                    
                    }
                    break;
                default:
                    {
                        provider = null;
                    }
                    break;
            }
            return provider;
        }

        static public string GetStatementByDBType(SQLStatementType statetype, DBType dbtype, object other)
        {
            string statement;
            switch (statetype)
            {
                case SQLStatementType.EXISTSLM:
                    {
                        switch (dbtype)
                        {
                            case DBType.MSSQL:
                                {
                                    statement = string.Format("select count(*) from master.dbo.sysobjects where xtype = 'U' and object_id(N'{0}') = id", Settings.Default.LMTABLE);
                                }
                                break;
                        }
                    }
                    break;
            }
            return null;
        }
    }
}
