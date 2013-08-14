using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace StoreManagement
{
    internal class LoginUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public DateTime LoginTime { get; set; }
        public bool Available { get; set; }
        public Dictionary<int, Folder> FolderList { get; set; }
        private LoginUser() { Available = false; }
        private static readonly LoginUser _obj = new LoginUser() { FolderList = new Dictionary<int,Folder>()};
        public static LoginUser CurrentUser
        {
            get
            {
                return _obj;
            }
        }
    }
}
