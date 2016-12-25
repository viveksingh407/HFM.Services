using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HFM.Data.EF;

namespace HFM.Data.Repository.Implementation
{
    public class DailyPurchaseRepository
    {
        public int DailyPurchaseItemId { get; set; }
        public int PurchasedItemId { get; set; }
        public string PurchasedItemName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int StoreLocationId { get; set; }
        public string StoreLocation { get; set; }
        public int ItemSubCategoryId { get; set; }
        public string ItemSubCategoryName { get; set; }
        public int ItemCategoryId { get; set; }
        public string ItemCategoryName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        private static HomeFinanceDBEntities context;

        public IList<DailyPurchaseRepository> Get()
        {
            DailyPurchaseRepository repo = new DailyPurchaseRepository();
            context = new HomeFinanceDBEntities();

            var data = (from a in context.DailyPurchases
                        join b in context.Items on a.PurchasedItemId equals b.ItemId
                        join c in context.Stores on b.StoreId equals c.StoreId
                        join d in context.ItemSubCategories on b.ItemSubCategoryId equals d.ItemSubCategoryId
                        join e in context.ItemCategories on b.ItemCategoryId equals e.ItemCategoryId
                        join f in context.PurchaseLocations on c.LocationId equals f.LocationId
                        select new DailyPurchaseRepository()
                        {
                            DailyPurchaseItemId = a.PurchasedItemId,
                            PurchasedItemId = a.PurchasedItemId,
                            PurchasedItemName = b.ItemName,
                            Price = a.Price,
                            Quantity = a.Quantity,
                            ItemSubCategoryId = d.ItemSubCategoryId,
                            ItemSubCategoryName = d.ItemSubCategoryName,
                            ItemCategoryId = e.ItemCategoryId,
                            ItemCategoryName = e.ItemCategoryName,
                            StoreId = c.StoreId,
                            StoreName = c.StoreName,
                            StoreLocationId = f.LocationId,
                            StoreLocation = f.LocationName,
                            PurchaseDate = a.PurchaseDate ?? default(DateTime),
                            CreatedDate = a.CreatedDate ?? default(DateTime),
                            ModifiedDate = a.ModifiedDate ?? default(DateTime)
                        });

            return data.ToList();
        }

        public DailyPurchaseRepository GetById(int dailyPurchaseId)
        {
            DailyPurchaseRepository repo = new DailyPurchaseRepository();
            context = new HomeFinanceDBEntities();

            var data = (from a in context.DailyPurchases
                        join b in context.Items on a.PurchasedItemId equals b.ItemId
                        join c in context.Stores on b.StoreId equals c.StoreId
                        join d in context.ItemSubCategories on b.ItemSubCategoryId equals d.ItemSubCategoryId
                        join e in context.ItemCategories on b.ItemCategoryId equals e.ItemCategoryId
                        join f in context.PurchaseLocations on c.LocationId equals f.LocationId
                        where a.DailyPurchaseId == dailyPurchaseId
                        select new DailyPurchaseRepository()
                        {
                            DailyPurchaseItemId = a.PurchasedItemId,
                            PurchasedItemId = a.PurchasedItemId,
                            PurchasedItemName = b.ItemName,
                            Price = a.Price,
                            Quantity = a.Quantity,
                            ItemSubCategoryId = d.ItemSubCategoryId,
                            ItemSubCategoryName = d.ItemSubCategoryName,
                            ItemCategoryId = e.ItemCategoryId,
                            ItemCategoryName = e.ItemCategoryName,
                            StoreId = c.StoreId,
                            StoreName = c.StoreName,
                            StoreLocationId = f.LocationId,
                            StoreLocation = f.LocationName,
                            PurchaseDate = a.PurchaseDate ?? default(DateTime),
                            CreatedDate = a.CreatedDate ?? default(DateTime),
                            ModifiedDate = a.ModifiedDate ?? default(DateTime)
                        }).FirstOrDefault();

            return data;
        }

        public DailyPurchaseRepository Add(DailyPurchaseRepository data)
        {
            DailyPurchaseRepository repo = new DailyPurchaseRepository();
            context = new HomeFinanceDBEntities();

            context.DailyPurchases.Add(new DailyPurchase()
            {
                PurchasedItemId = data.PurchasedItemId,
                Price = data.Price,
                Quantity = data.Quantity,
                PurchaseDate = data.PurchaseDate,
                ModifiedDate = data.ModifiedDate == DateTime.MinValue ? DateTime.Now : data.ModifiedDate
            });

            context.SaveChanges();

            return data;
        }

        public DailyPurchaseRepository Update(DailyPurchaseRepository data)
        {
            DailyPurchaseRepository repo = new DailyPurchaseRepository();
            context = new HomeFinanceDBEntities();

            try
            {
                var details = context.DailyPurchases.Where(n => n.DailyPurchaseId == data.DailyPurchaseItemId).First();
                
                details.PurchasedItemId = data.PurchasedItemId;
                details.Price = data.Price;
                details.Quantity = data.Quantity;
                details.PurchaseDate = data.PurchaseDate;
                details.CreatedDate = data.CreatedDate;
                details.ModifiedDate = data.ModifiedDate;

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
            DailyPurchaseRepository repo = new DailyPurchaseRepository();
            context = new HomeFinanceDBEntities();

            var details = context.DailyPurchases.Where(n => n.DailyPurchaseId == id).First();

            context.DailyPurchases.Remove(details);
        }
    }
}
