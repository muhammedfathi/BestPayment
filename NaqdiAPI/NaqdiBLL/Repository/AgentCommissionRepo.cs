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

      

        public void Delet(AgentCommissions Entity)
        {
            db.AgentCommissions.Remove(Entity);
            db.SaveChanges();
        }

        public IList<AgentCommissions> FindByCondition(Expression<Func<AgentCommissions, bool>> expression)
        {
            return db.AgentCommissions.Where(expression).ToList();
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
