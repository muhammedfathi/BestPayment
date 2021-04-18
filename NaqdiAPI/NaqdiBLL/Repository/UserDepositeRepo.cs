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
    public class UserDepositeRepo : BestPaymentRepo<UsersDeposit>
    {

        private NakqdiAppContext db;

        public UserDepositeRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }

        public void add(UsersDeposit newEntity)
        {
            db.UsersDeposit.Add(newEntity);
            db.SaveChanges();
        }

        public IList<UsersDeposit> FindByCondition(Expression<Func<UsersDeposit, bool>> expression)
        {
            return db.UsersDeposit.Where(expression).ToList();
        }

        public void Delet(UsersDeposit Entity)
        {
            db.UsersDeposit.Remove(Entity);
            db.SaveChanges();
        }

        public IList<UsersDeposit> getAll()
        {
            return db.UsersDeposit.ToList();
        }

        public void update(UsersDeposit oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}


