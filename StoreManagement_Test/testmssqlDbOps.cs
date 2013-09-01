using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreManagement;

namespace StoreManagement_Test
{
    [TestClass]
    public class testmssqlDbOps
    {
        [TestMethod]
        public void testConnect()
        {
            IDBProvider mssqldb = new StoreManagement.MSSQLProvider();
        }
    }
}
