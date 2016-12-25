using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HFM.Data.EF;

namespace HFM.Data.Repository.Implementation
{
    public class BankAccountTypeRepository
    {
        public int BankAccountTypeId { get; set; }
        public string BankAccountTypeName { get; set; }

        private static HomeFinanceDBEntities context;

        public IList<BankAccountTypeRepository> Get()
        {
            BankAccountTypeRepository repo = new BankAccountTypeRepository();
            context = new HomeFinanceDBEntities();

            var data = (from a in context.BankAccountTypes
                        select new BankAccountTypeRepository()
                        {
                            BankAccountTypeId = a.BankAccountTypeId,
                            BankAccountTypeName = a.BankAccountTypeName
                        });

            return data.ToList();
        }

        public BankAccountTypeRepository GetById(int dailyPurchaseId)
        {
            BankAccountTypeRepository repo = new BankAccountTypeRepository();
            context = new HomeFinanceDBEntities();

            var data = (from a in context.BankAccountTypes
                        select new BankAccountTypeRepository()
                        {
                            BankAccountTypeId = a.BankAccountTypeId,
                            BankAccountTypeName = a.BankAccountTypeName
                        }).FirstOrDefault();

            return data;
        }

        public BankAccountTypeRepository Add(BankAccountTypeRepository data)
        {
            BankAccountTypeRepository repo = new BankAccountTypeRepository();
            context = new HomeFinanceDBEntities();

            context.BankAccountTypes.Add(new BankAccountType()
            {
                BankAccountTypeName = BankAccountTypeName
            });

            context.SaveChanges();

            return data;
        }

        public BankAccountTypeRepository Update(BankAccountTypeRepository data)
        {
            BankAccountTypeRepository repo = new BankAccountTypeRepository();
            context = new HomeFinanceDBEntities();

            try
            {
                var details = context.BankAccountTypes.Where(n => n.BankAccountTypeId == data.BankAccountTypeId).First();

                details.BankAccountTypeName = data.BankAccountTypeName;

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
            BankAccountTypeRepository repo = new BankAccountTypeRepository();
            context = new HomeFinanceDBEntities();

            var details = context.BankAccountTypes.Where(n => n.BankAccountTypeId == id).First();

            context.BankAccountTypes.Remove(details);
        }
    }
}
