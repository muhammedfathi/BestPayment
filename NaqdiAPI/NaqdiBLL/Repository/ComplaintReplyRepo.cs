using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.Reply.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public Reply Find(int Key)
        {
            return db.Reply.Find(Key) ?? null;
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