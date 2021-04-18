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

        public IList<PayMent_Cards> FindByCondition(Expression<Func<PayMent_Cards, bool>> expression)
        {
            return db.PayMent_Cards.Where(expression).ToList();
        }

        public void Delet(PayMent_Cards Entity)
        {
            db.PayMent_Cards.Remove(Entity);
            db.SaveChanges();
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

