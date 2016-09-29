using System;
using System.Collections.Generic;
using System.Linq;
using HFM.Data.Repository.Implementation;

namespace HFM.Business.Data
{
    public class ItemSubCategory
    {
        public int ItemSubCategoryId { get; set; }
        public string ItemSubCategoryName { get; set; }
        public int ItemCategoryId { get; set; }
        public IList<Item> Items { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public ItemSubCategory GetItemById(int itemSubCategoryId)
        {
            var repo = new ItemSubCategoryRepository();
            var item = repo.GetById(itemSubCategoryId);

            return new ItemSubCategory()
            {
                ItemSubCategoryId = item.ItemSubCategoryId ?? default(int),
                ItemSubCategoryName = item.ItemSubCategoryName,
                ItemCategoryId = item.ItemCategoryId
            };
        }

        public IList<ItemSubCategory> GetItem()
        {
            var repo = new ItemSubCategoryRepository();
            var itemSubCategory = repo.Get();

            var itemSubCategories = itemSubCategory.Select(n => new ItemSubCategory()
            {
                ItemSubCategoryId = n.ItemSubCategoryId ?? default(int),
                ItemSubCategoryName = n.ItemSubCategoryName,
                ItemCategoryId = n.ItemCategoryId
            }).ToList();

            var items = new Item();
            var data = items.GetItems();

            foreach (var subCategory in itemSubCategories)
            {
                subCategory.Items = data.Where(n => n.ItemCategoryId == subCategory.ItemCategoryId).ToList();
            }

            return itemSubCategories;
        }
    }
}
