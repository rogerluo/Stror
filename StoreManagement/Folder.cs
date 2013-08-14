using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement
{
    public class Folder
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public HashSet<int> Childs { get; set; }
        
        static public bool RebuildFolderRelationship(Dictionary<int, Folder> folders)
        {
            foreach (var folderOut in folders)
            {
                folderOut.Value.Childs.Clear();
                foreach (var folderIn in folders)
                {
                    if (folderIn.Value.ParentID == folderOut.Key)
                    {
                        folderOut.Value.Childs.Add(folderIn.Key);
                    }
                }
            }
            return true;
        }
    }
    
}
