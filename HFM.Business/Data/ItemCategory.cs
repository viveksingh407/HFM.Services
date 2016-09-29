using System;
using System.Collections.Generic;
using System.Linq;
using HFM.Data.Repository.Implementation;

namespace HFM.Business.Data
{
    public class ItemCategory
    {
        public int ItemCategoryId { get; set; }
        public string ItemCategoryName { get; set; }
        public IList<ItemSubCategory> ItemSubCategories { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public ItemCategory GetItemById(int ItemCategoryId)
        {
            var repo = new ItemsCategoryRepository();
            var item = repo.GetById(ItemCategoryId);

            return new ItemCategory()
            {
                ItemCategoryId = item.ItemCategoryId ?? default(int),
                ItemCategoryName = item.ItemCategoryName
            };
        }

        public IList<ItemCategory> GetItem()
        {
            var repo = new ItemsCategoryRepository();
            var ItemCategory = repo.Get();

            var itemSubCategories = ItemCategory.Select(n => new ItemCategory()
            {
                ItemCategoryId = n.ItemCategoryId ?? default(int),
                ItemCategoryName = n.ItemCategoryName
            }).ToList();

            var itemSubCategory = new ItemSubCategory();
            var data = itemSubCategory.GetItem();

            foreach (var category in itemSubCategories)
            {
                category.ItemSubCategories = data.Where(n => n.ItemCategoryId == category.ItemCategoryId).ToList();
            }

            return itemSubCategories;
        }

        //private ItemCategory GetItemCategory()
        //{

        //}
    }
}
