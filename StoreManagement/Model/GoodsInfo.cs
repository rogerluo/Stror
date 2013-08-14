using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.Model
{
    internal class GoodsInfo
    {
        public Int64 GoodsId { get; private set; }
        public Int32 FolderId { get; private set; }
        public string FullName { get; private set; }
        public string AbbrName { get; private set; }
        public string Unit { get; private set; }
        public string Barcode { get; private set; }
        public DateTime Expired { get; private set; }
        public Int32 BarCodeFmt { get; private set; }
        public double Price { get; private set; }
        public double Cost { get; private set; }
        public Int32 SeasonId { get; private set; }
        public Int32 BrandId { get; private set; }
        public Int32 StuffId { get; private set; }
        public bool IsNew { get; set; }

        public GoodsInfo(Int64 goodsId)
        {
            IsNew = false;    
        }

        public GoodsInfo()
        {
            IsNew = true;
        }

        public bool Init()
        {
            return false;
        }

        public bool Update()
        {
            if (IsNew)
            {
                // call insert procedure
                // success
                IsNew = false;
            }
            else 
            {
                // call update procedure
            }
            return false;
        }
    }
}
