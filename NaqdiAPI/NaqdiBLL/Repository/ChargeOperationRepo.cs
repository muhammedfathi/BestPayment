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
    public class ChargeOperationRepo : BestPaymentRepo<ChargeOperation>
    {

        private NakqdiAppContext db;
        public ChargeOperationRepo(NakqdiAppContext _db)
        {
            this.db = _db;

        }

        public void add(ChargeOperation newEntity)
        {
            db.ChargeOperations.Add(newEntity);
            db.SaveChanges();
        }

        public IList<ChargeOperation> FindByCondition(Expression<Func<ChargeOperation, bool>> expression)
        {
            return db.ChargeOperations.Where(expression).ToList();
        }

        public void Delet(ChargeOperation Entity)
        {
            db.ChargeOperations.Remove(Entity);
            db.SaveChanges();
        }

        public IList<ChargeOperation> getAll()
        {
            return db.ChargeOperations.ToList();
        }

        public void update(ChargeOperation oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}

