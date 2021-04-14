using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.Login_Information.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public Login_Information Find(int Key)
        {
            return db.Login_Information.Find(Key) ?? null;
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
