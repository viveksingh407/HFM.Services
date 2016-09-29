using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HFM.Business;

namespace HFM.Web.Models
{
    public class ItemCategoryModel
    {
        public int ItemCategoryId { get; set; }
        public string ItemCategoryName { get; set; }

        public ItemCategoryModel GetItemCategoryModel(int subCategoryId)
        {
            var facade = new ItemCategoryFacade();

            var itemCategory = facade.GetCategoryFromSubCategoryId(subCategoryId);

            return new ItemCategoryModel()
            {
                ItemCategoryId = itemCategory.ItemCategoryId,
                ItemCategoryName = itemCategory.ItemCategoryName
            };
        }

        //private ItemModel GetItemModelData()
        //{
        //    var data = new ItemModel()
        //    {
        //        ItemId = 1,
        //        ItemName = ,
        //        ItemSubCategoryName = 1,
        //        ItemCategoryName = 1,
        //        ItemQuantity = 1,
        //        ItemPrice = 1,
        //    }

        //    return data;
        //}
    }
}