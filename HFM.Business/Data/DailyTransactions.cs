using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFM.Data.Repository.Implementation;

namespace HFM.Business.Data
{
    public class DailyTransactions
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

        public IList<DailyTransactions> GetDailyTransactions()
        {
            DailyPurchaseRepository repo = new DailyPurchaseRepository();

            var transactions = repo.Get();

            return this.GetDailyTransactions(transactions);
        }

        public IList<DailyTransactions> GetDailyTransactions(DateTime purchasedDate)
        {
            DailyPurchaseRepository repo = new DailyPurchaseRepository();

            var transactions = repo.Get();

            var filteredTransactions = transactions?.Where(n => n.PurchaseDate == purchasedDate);

            return this.GetDailyTransactions(filteredTransactions);
        }

        public IList<DailyTransactions> GetDailyTransactions(DateTime purchasedFromDate, DateTime purchasedToDate)
        {
            DailyPurchaseRepository repo = new DailyPurchaseRepository();

            var transactions = repo.Get();

            var filteredTransactions = transactions?.Where(n => n.PurchaseDate >= purchasedFromDate && n.PurchaseDate <= purchasedToDate);

            return this.GetDailyTransactions(filteredTransactions);
        }

        public bool AddDailyTransaction(DailyTransactions dailyTransaction)
        {
            var isSaveSuccessful = false;
            DailyPurchaseRepository repo = new DailyPurchaseRepository();

            repo.Add(new DailyPurchaseRepository()
            {
                PurchasedItemId = dailyTransaction.PurchasedItemId,
                Price = dailyTransaction.Price,
                Quantity = dailyTransaction.Quantity,
                PurchaseDate = dailyTransaction.PurchaseDate,
                ModifiedDate = dailyTransaction.ModifiedDate
            });

            return isSaveSuccessful;
        }

        public bool AddDailyTransactions(IList<DailyTransactions> dailyTransactions)
        {
            var isSaveSuccessful = false;
            DailyPurchaseRepository repo = new DailyPurchaseRepository();

            foreach (var transaction in dailyTransactions)
            {
                repo.Add(new DailyPurchaseRepository()
                {
                    PurchasedItemId = transaction.PurchasedItemId,
                    Price = transaction.Price,
                    Quantity = transaction.Quantity,
                    PurchaseDate = transaction.PurchaseDate,
                    ModifiedDate = transaction.ModifiedDate
                });
            }

            return isSaveSuccessful;
        }

        private IList<DailyTransactions> GetDailyTransactions(IEnumerable<DailyPurchaseRepository> transactions)
        {
            return transactions.Select(n => new DailyTransactions()
            {
                DailyPurchaseItemId = n.PurchasedItemId,
                PurchasedItemId = n.PurchasedItemId,
                PurchasedItemName = n.PurchasedItemName,
                Price = n.Price,
                Quantity = n.Quantity,
                ItemSubCategoryId = n.ItemSubCategoryId,
                ItemSubCategoryName = n.ItemSubCategoryName,
                ItemCategoryId = n.ItemCategoryId,
                ItemCategoryName = n.ItemCategoryName,
                StoreId = n.StoreId,
                StoreName = n.StoreName,
                StoreLocationId = n.StoreLocationId,
                StoreLocation = n.StoreLocation,
                PurchaseDate = n.PurchaseDate,
                CreatedDate = n.CreatedDate,
                ModifiedDate = n.ModifiedDate
            }).ToList();
        }
    }
}
