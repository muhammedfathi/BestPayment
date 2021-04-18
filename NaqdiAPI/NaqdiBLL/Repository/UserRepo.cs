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
    public class UserRepo : BestPaymentRepo<TUser>
    {
        private NakqdiAppContext db;
        public UserRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }



        public IList<TUser> getAll()
        {
            return db.TUser.ToList();
           

        }
        public void add(TUser newEntity)
        {
            db.TUser.Add(newEntity);
            db.SaveChanges();

        }

        public void update(TUser oldEntity)
        {
           
                db.Entry(oldEntity).State = EntityState.Modified;
                db.SaveChanges();
           
        }


        public IList<TUser> FindByCondition(Expression<Func<TUser, bool>> expression)
        {
            return db.TUser.Where(expression).ToList();
        }

        public void Delet(TUser Entity)
        {
            db.TUser.Remove(Entity);
            db.SaveChanges();
        }




    }
}
