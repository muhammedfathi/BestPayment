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
    public class ExecutionRes_Repo : BestPaymentRepo<Execution_Response>
    {


        private NakqdiAppContext db;

        public ExecutionRes_Repo(NakqdiAppContext _db){
            this.db = _db;
        }

        public void add(Execution_Response newEntity)
        {
            db.Execution_Responses.Add(newEntity);
            db.SaveChanges();
        }


        public IList<Execution_Response> FindByCondition(Expression<Func<Execution_Response, bool>> expression)
        {
            return db.Execution_Responses.Where(expression).ToList();
        }

        public void Delet(Execution_Response Entity)
        {
            db.Execution_Responses.Remove(Entity);
            db.SaveChanges();
        }

        public IList<Execution_Response> getAll()
        {
            return db.Execution_Responses.ToList();
        }

        public void update(Execution_Response oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
