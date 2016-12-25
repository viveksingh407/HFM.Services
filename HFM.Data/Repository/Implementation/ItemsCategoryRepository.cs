using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFM.Data.EF;

namespace HFM.Data.Repository.Implementation
{
    public class ItemsCategoryRepository
    {
        public int? ItemCategoryId { get; set; }
        public string ItemCategoryName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        private static HomeFinanceDBEntities context;

        public IList<ItemsCategoryRepository> Get()
        {
            ItemsCategoryRepository repo = new ItemsCategoryRepository();
            context = new HomeFinanceDBEntities();

            return context.ItemCategories.Select(n => new ItemsCategoryRepository()
            {
                ItemCategoryId = n.ItemCategoryId,
                ItemCategoryName = n.ItemCategoryName
            }).ToList();
        }

        public ItemsCategoryRepository GetById(int id)
        {
            ItemsCategoryRepository repo = new ItemsCategoryRepository();
            context = new HomeFinanceDBEntities();

            return context.ItemCategories.Where(n => n.ItemCategoryId == id).Select(n => new ItemsCategoryRepository()
            {
                ItemCategoryId = n.ItemCategoryId,
                ItemCategoryName = n.ItemCategoryName
            }).FirstOrDefault();
        }

        public ItemsCategoryRepository Add(ItemsCategoryRepository data)
        {
            ItemsCategoryRepository repo = new ItemsCategoryRepository();
            context = new HomeFinanceDBEntities();

            context.ItemCategories.Add(new ItemCategory()
            {
                ItemCategoryId = data.ItemCategoryId ?? default(int),
                ItemCategoryName = data.ItemCategoryName
            });

            return data;
        }

        public ItemsCategoryRepository Update(ItemsCategoryRepository data)
        {
            ItemsCategoryRepository repo = new ItemsCategoryRepository();
            context = new HomeFinanceDBEntities();

            try
            {
                var details = context.ItemCategories.Where(n => n.ItemCategoryId == data.ItemCategoryId).First();

                details.ItemCategoryName = data.ItemCategoryName;

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
            ItemsCategoryRepository repo = new ItemsCategoryRepository();
            context = new HomeFinanceDBEntities();

            var details = context.ItemCategories.Where(n => n.ItemCategoryId == id).First();

            context.ItemCategories.Remove(details);
        }
    }
}
