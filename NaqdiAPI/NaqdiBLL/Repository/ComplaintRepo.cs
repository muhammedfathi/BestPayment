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

        public IList<Complaint> FindByCondition(Expression<Func<Complaint, bool>> expression)
        {
            return db.Complaint.Where(expression).ToList();
        }

        public void Delet(Complaint Entity)
        {
            db.Complaint.Remove(Entity);
            db.SaveChanges();
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
