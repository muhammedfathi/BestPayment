using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.Execution_Responses.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public Execution_Response Find(int Key)
        {
            return db.Execution_Responses.Find(Key) ?? null;
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
