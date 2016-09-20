using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HFM.Business;

namespace HFM.Web.Models
{
    public class ItemSubCategoryModel
    {
        public int ItemSubCategoryId { get; set; }
        public string ItemSubCategoryName { get; set; }

        public ItemSubCategoryModel GetItemCategoryModel(int itemId)
        {
            var facade = new ItemCategoryFacade();
            var itemSubCategory = facade.GetSubCategoryFromItemId(itemId);

            return new ItemSubCategoryModel()
            {
                ItemSubCategoryId = itemSubCategory.ItemSubCategoryId,
                ItemSubCategoryName = itemSubCategory.ItemSubCategoryName
            };
        }
    }
}