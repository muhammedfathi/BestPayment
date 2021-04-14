using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.UsersDeposit.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public UsersDeposit Find(int Key)
        {
            return db.UsersDeposit.Find(Key) ?? null;
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


