using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HFM.Web.Models;

namespace HFM.Web.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetItems(string query)
        {
            var data = this.GetItems();
            IList<KeyValuePair<int, string>> filteredData;

            if (!string.IsNullOrEmpty(query))
            {
                filteredData = data
                    .Where(n => n.ItemName.StartsWith(query, StringComparison.InvariantCultureIgnoreCase))
                    .Select(n => new KeyValuePair<int, string>(n.ItemId, n.ItemName))
                    .ToList();
            }
            else
            {
                filteredData = data.Select(n => new KeyValuePair<int, string>(n.ItemId, n.ItemName)).ToList();
            }

            return new JsonResult() { Data = filteredData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public JsonResult GetCategoryFromSubCategory(int subCategoryId)
        {
            var data = this.GetItemCategories(subCategoryId);
            var categoryData = new KeyValuePair<int, string>();

            if (data != null)
            {
                categoryData = new KeyValuePair<int, string>(data.ItemCategoryId, data.ItemCategoryName);
            }

            //categoryData = new KeyValuePair<int, string>(1, "Test1");
            return new JsonResult() { Data = categoryData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public JsonResult GeSubCategoryFromItemId(int itemId)
        {
            var data = this.GetItemSubCategories(itemId);
            var subCategoryData = new KeyValuePair<int, string>();

            if (data != null)
            {
                subCategoryData = new KeyValuePair<int, string>(data.ItemSubCategoryId, data.ItemSubCategoryName);
            }

            return new JsonResult() { Data = subCategoryData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private string[] GetTransactionDetails()
        {
            var details = new TransactionDetails();
            details.GetTransactionDetails();

            return details.FinanceTransactionDetails.Select(n => n.TransactionDetailsName).ToArray();
        }

        private ItemCategoryModel GetItemCategories(int subCategoryId)
        {
            var data = new ItemCategoryModel();

            //return new ItemCategoryModel() { ItemCategoryId = 1, ItemCategoryName = "Test1" };

            return data.GetItemCategoryModel(subCategoryId);
        }

        private ItemSubCategoryModel GetItemSubCategories(int itemId)
        {
            var data = new ItemSubCategoryModel();
            return data.GetItemCategoryModel(itemId);
        }

        private IList<ItemModel> GetItems()
        {
            var data = new ItemModel();
            return data.GetItemModel();
        }
    }
}