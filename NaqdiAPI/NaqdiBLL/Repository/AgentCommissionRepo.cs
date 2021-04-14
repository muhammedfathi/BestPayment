using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaqdiBLL.Repository
{
    public class AgentCommissionRepo : BestPaymentRepo<AgentCommissions>
    {
        private NakqdiAppContext db;
     
        public AgentCommissionRepo(NakqdiAppContext _db)
        {

            this.db = _db;

        }


        public void add(AgentCommissions newEntity)
        {
            db.AgentCommissions.Add(newEntity);
            db.SaveChanges();
        }

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.AgentCommissions.Remove(Find(id));
                db.SaveChanges();

            }
        }

        public AgentCommissions Find(int Key)
        {
            return db.AgentCommissions.Find(Key) ?? null;
        }

        public IList<AgentCommissions> getAll()
        {
            return db.AgentCommissions.ToList();
        }

        public void update(AgentCommissions oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
