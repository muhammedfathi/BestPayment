using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaqdiBLL.Repository
{
    public class CompanyRepo : BestPaymentRepo<Company>
    {
        private NakqdiAppContext db;
        public CompanyRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }



        public IList<Company> getAll()
        {
            return db.Company.ToList();
            

        }
        public void add(Company newEntity)
        {
            db.Company.Add(newEntity);
            db.SaveChanges();

        }

        public void update(Company oldEntity)
        {
            
                db.Entry(oldEntity).State = EntityState.Modified;
                db.SaveChanges();
          
        }

        public void Delet(int id)
        {

            if (Find(id) != null)
            {
                db.Company.Remove(Find(id));
                db.SaveChanges();

            }
        }

        public Company Find(int Key)
        {
            return db.Company.Find(Key);
        }

        
    }
}