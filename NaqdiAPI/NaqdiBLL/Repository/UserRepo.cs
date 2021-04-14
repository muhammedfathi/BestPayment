using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delet(int id)
        {

            if (Find(id) != null)
            {
                db.TUser.Remove(Find(id));
                db.SaveChanges();

            }
        }

        public TUser Find(int Key)
        {
            return db.TUser.Find(Key);
        }

    }
}
