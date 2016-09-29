using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFM.Business.Data;

namespace HFM.Business
{
    public class ItemCategoryFacade
    {
        public ItemCategory GetCategoryFromSubCategoryId(int subCategoryId)
        {
            ItemCategory category = new ItemCategory();
            ItemSubCategory subCategory = new ItemSubCategory();

            var subCategoryData = subCategory.GetItemById(subCategoryId);

            return category.GetItemById(subCategoryData.ItemCategoryId);
        }

        public ItemSubCategory GetSubCategoryFromItemId(int itemId)
        {
            ItemSubCategory subCategory = new ItemSubCategory();
            Item item = new Item();

            var itemData = item.GetItemById(itemId);

            return subCategory.GetItemById(itemData.ItemSubCategoryId);
        }
    }
}
