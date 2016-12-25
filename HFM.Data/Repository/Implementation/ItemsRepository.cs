using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFM.Data.EF;

namespace HFM.Data.Repository.Implementation
{
    public class ItemsRepository
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int? ItemSubCategoryId { get; set; }
        public int? ItemCategoryId { get; set; }
        public string ItemQuantity { get; set; }
        public decimal ItemPrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        private static HomeFinanceDBEntities context;

        public IList<ItemsRepository> Get()
        {
            ItemsRepository repo = new ItemsRepository();
            context = new HomeFinanceDBEntities();

            return context.Items.Select(n => new ItemsRepository()
            {
                ItemId = n.ItemId,
                ItemName = n.ItemName,
                ItemSubCategoryId = n.ItemSubCategoryId,
                ItemCategoryId = n.ItemCategoryId
            }).ToList();
        }

        public ItemsRepository GetById(int id)
        {
            ItemsRepository repo = new ItemsRepository();
            context = new HomeFinanceDBEntities();

            return context.Items.Where(n => n.ItemId == id).Select(n => new ItemsRepository()
            {
                ItemId = n.ItemId,
                ItemName = n.ItemName,
                ItemSubCategoryId = n.ItemSubCategoryId,
                ItemCategoryId = n.ItemCategoryId
            }).FirstOrDefault();
        }

        public ItemsRepository Add(ItemsRepository data)
        {
            ItemsRepository repo = new ItemsRepository();
            context = new HomeFinanceDBEntities();

            context.Items.Add(new Item()
            {
                ItemId = data.ItemId,
                ItemName = data.ItemName,
                ItemSubCategoryId = data.ItemSubCategoryId,
                ItemCategoryId = data.ItemCategoryId
            });

            return data;
        }

        public ItemsRepository Update(ItemsRepository data)
        {
            ItemsRepository repo = new ItemsRepository();
            context = new HomeFinanceDBEntities();

            try
            {
                var details = context.Items.Where(n => n.ItemId == data.ItemId).First();

                details.ItemName = data.ItemName;

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        public void Delete(int id)
        {
            ItemsRepository repo = new ItemsRepository();
            context = new HomeFinanceDBEntities();

            var details = context.Items.Where(n => n.ItemId == id).First();

            context.Items.Remove(details);
        }
    }
}
