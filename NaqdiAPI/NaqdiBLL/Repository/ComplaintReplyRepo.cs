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
    class ComplaintReplyRepo : BestPaymentRepo<Reply>
    {

        private NakqdiAppContext db;

        public ComplaintReplyRepo (NakqdiAppContext _db)
        {

            this.db = _db;

        }

        public void add(Reply newEntity)
        {
            db.Reply.Add(newEntity);
            db.SaveChanges();
        }

        public IList<Reply> FindByCondition(Expression<Func<Reply, bool>> expression)
        {
            return db.Reply.Where(expression).ToList();
        }

        public void Delet(Reply Entity)
        {
            db.Reply.Remove(Entity);
            db.SaveChanges();
        }


        public IList<Reply> getAll()
        {
            return db.Reply.ToList();
        }

        public void update(Reply oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}