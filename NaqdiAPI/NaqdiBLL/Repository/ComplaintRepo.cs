using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaqdiBLL.Repository
{
    class ComplaintRepo : BestPaymentRepo<Complaint>
    {

        private NakqdiAppContext db;

        public ComplaintRepo(NakqdiAppContext _db)
        {

            this.db = _db;

        }

        public void add(Complaint newEntity)
        {
            db.Complaint.Add(newEntity);
            db.SaveChanges();
        }

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.Complaint.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public Complaint Find(int Key)
        {
            return db.Complaint.Find(Key) ?? null;
        }

        public IList<Complaint> getAll()
        {
            return db.Complaint.ToList();
        }

        public void update(Complaint oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
