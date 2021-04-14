using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaqdiBLL.Repository
{
    public class PaymentCardRepo : BestPaymentRepo<PayMent_Cards>
    {
        private NakqdiAppContext db;

        public PaymentCardRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }

        public void add(PayMent_Cards newEntity)
        {
            db.PayMent_Cards.Add(newEntity);
            db.SaveChanges();
        }

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.PayMent_Cards.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public PayMent_Cards Find(int Key)
        {
            return db.PayMent_Cards.Find(Key) ?? null;
        }

        public IList<PayMent_Cards> getAll()
        {
            return db.PayMent_Cards.ToList();
        }

        public void update(PayMent_Cards oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }


    }
}

