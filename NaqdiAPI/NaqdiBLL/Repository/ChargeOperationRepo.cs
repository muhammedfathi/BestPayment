using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.ChargeOperations.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public ChargeOperation Find(int Key)
        {
            return db.ChargeOperations.Find(Key) ?? null;
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

