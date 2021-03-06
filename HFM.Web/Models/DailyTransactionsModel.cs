﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HFM.Business.Data;

namespace HFM.Web.Models
{
    public class DailyTransactionsModel
    {
        public int DailyPurchaseId { get; set; }
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

        public IList<DailyTransactionsModel> GetDailyTransactions()
        {
            var transactions = new DailyTransactions();
            var dailyTransactions = transactions.GetDailyTransactions();
            return GetDailyTransactions(dailyTransactions);
        }

        public IList<DailyTransactionsModel> GetDailyTransactions(DateTime purchasedDate)
        {
            var transactions = new DailyTransactions();
            var dailyTransactions = transactions.GetDailyTransactions();
            return GetDailyTransactions(dailyTransactions.Where(n => n.PurchaseDate == purchasedDate));
        }

        public IList<DailyTransactionsModel> GetDailyTransactions(DateTime purchasedFromDate, DateTime purchasedToDate)
        {
            var transactions = new DailyTransactions();
            var dailyTransactions = transactions.GetDailyTransactions();
            return GetDailyTransactions(dailyTransactions.Where(n => n.PurchaseDate >= purchasedFromDate && n.PurchaseDate <= purchasedToDate));
        }

        public bool AddDailyTransaction(DailyTransactionsModel dailyTransaction)
        {
            var isSaveSuccessful = false;
            var tran = new DailyTransactions();

            tran.AddDailyTransaction(new DailyTransactions()
            {
                PurchasedItemId = dailyTransaction.PurchasedItemId,
                Price = dailyTransaction.Price,
                Quantity = dailyTransaction.Quantity,
                PurchaseDate = dailyTransaction.PurchaseDate,
                ModifiedDate = dailyTransaction.ModifiedDate == DateTime.MinValue ? DateTime.Now : dailyTransaction.ModifiedDate
            });

            return isSaveSuccessful;
        }

        public bool AddDailyTransactions(IList<DailyTransactionsModel> dailyTransactions)
        {
            var isSaveSuccessful = false;
            var tran = new DailyTransactions();
            var transactions = new List<DailyTransactions>() as IList<DailyTransactions>;

            foreach (var transaction in dailyTransactions)
            {
                transactions.Add(new DailyTransactions()
                {
                    PurchasedItemId = transaction.PurchasedItemId,
                    Price = transaction.Price,
                    Quantity = transaction.Quantity,
                    PurchaseDate = transaction.PurchaseDate,
                    ModifiedDate = transaction.ModifiedDate
                });
            }

            tran.AddDailyTransactions(transactions);

            return isSaveSuccessful;
        }

        private IList<DailyTransactionsModel> GetDailyTransactions(IEnumerable<DailyTransactions> transactions)
        {
            return transactions.Select(n => new DailyTransactionsModel()
            {
                DailyPurchaseId = n.PurchasedItemId,
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