using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace NaqdiBLL.Repository
{
   public  class LoggginInfoRepo: BestPaymentRepo<Login_Information>
    {

        private NakqdiAppContext db;

        public LoggginInfoRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }

        public void add(Login_Information newEntity)
        {
            db.Login_Information.Add(newEntity);
            db.SaveChanges();
        }

        public IList<Login_Information> FindByCondition(Expression<Func<Login_Information, bool>> expression)
        {
            return db.Login_Information.Where(expression).ToList();
        }

        public void Delet(Login_Information Entity)
        {
            db.Login_Information.Remove(Entity);
            db.SaveChanges();
        }

        public IList<Login_Information> getAll()
        {
            return db.Login_Information.ToList();
        }

        public void update(Login_Information oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }


    }
}
