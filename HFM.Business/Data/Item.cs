using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFM.Data.Repository.Implementation;

namespace HFM.Business.Data
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string Quantity { get; set; }
        public int ItemSubCategoryId { get; set; }
        public int ItemCategoryId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public Item GetItemById(int itemId)
        {
            ItemsRepository repo = new ItemsRepository();
            var item = repo.GetById(itemId);

            return new Item()
            {
                ItemId = item.ItemId,
                ItemName = item.ItemName,
                ItemSubCategoryId = item.ItemSubCategoryId ?? default(int),
                ItemCategoryId = item.ItemCategoryId ?? default(int)
            };
        }

        public IList<Item> GetItems()
        {
            ItemsRepository repo = new ItemsRepository();
            var items = repo.Get();

            return items.Select(n => new Item()
            {
                ItemId = n.ItemId,
                ItemName = n.ItemName,
                ItemSubCategoryId = n.ItemSubCategoryId ?? default(int),
                ItemCategoryId = n.ItemCategoryId ?? default(int)
            }).ToList();
        }
    }
}
