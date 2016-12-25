using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFM.Data.EF;

namespace HFM.Data.Repository.Implementation
{
    public class ItemSubCategoryRepository
    {
        public int? ItemSubCategoryId { get; set; }
        public string ItemSubCategoryName { get; set; }
        public int ItemCategoryId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        private static HomeFinanceDBEntities context;

        public IList<ItemSubCategoryRepository> Get()
        {
            ItemSubCategoryRepository repo = new ItemSubCategoryRepository();
            context = new HomeFinanceDBEntities();

            return context.ItemSubCategories.Select(n => new ItemSubCategoryRepository()
            {
                ItemSubCategoryId = n.ItemSubCategoryId,
                ItemSubCategoryName = n.ItemSubCategoryName,
                ItemCategoryId = n.ItemCategoryId ?? default(int)
            }).ToList();
        }

        public ItemSubCategoryRepository GetById(int id)
        {
            ItemSubCategoryRepository repo = new ItemSubCategoryRepository();
            context = new HomeFinanceDBEntities();

            return context.ItemSubCategories.Where(n => n.ItemSubCategoryId == id).Select(n => new ItemSubCategoryRepository()
            {
                ItemSubCategoryId = n.ItemSubCategoryId,
                ItemSubCategoryName = n.ItemSubCategoryName,
                ItemCategoryId = n.ItemCategoryId ?? default(int)
            }).FirstOrDefault();
        }

        public ItemSubCategoryRepository Add(ItemSubCategoryRepository data)
        {
            ItemSubCategoryRepository repo = new ItemSubCategoryRepository();
            context = new HomeFinanceDBEntities();

            context.ItemSubCategories.Add(new ItemSubCategory()
            {
                ItemSubCategoryId = data.ItemSubCategoryId ?? default(int),
                ItemSubCategoryName = data.ItemSubCategoryName
            });

            return data;
        }

        public ItemSubCategoryRepository Update(ItemSubCategoryRepository data)
        {
            ItemSubCategoryRepository repo = new ItemSubCategoryRepository();
            context = new HomeFinanceDBEntities();

            try
            {
                var details = context.ItemSubCategories.Where(n => n.ItemSubCategoryId == data.ItemSubCategoryId).First();

                details.ItemSubCategoryName = data.ItemSubCategoryName;

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
            ItemSubCategoryRepository repo = new ItemSubCategoryRepository();
            context = new HomeFinanceDBEntities();

            var details = context.ItemSubCategories.Where(n => n.ItemSubCategoryId == id).First();

            context.ItemSubCategories.Remove(details);
        }
    }
}
