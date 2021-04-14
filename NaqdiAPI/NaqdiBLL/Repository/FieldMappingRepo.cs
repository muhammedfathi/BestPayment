using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaqdiBLL.Repository
{
    class FieldMappingRepo: BestPaymentRepo<Fields_Mapping>
    {
        private NakqdiAppContext db;

        public FieldMappingRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }
        public void add(Fields_Mapping newEntity)
        {
            db.Fields_Mappings.Add(newEntity);
            db.SaveChanges();
        }

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.Fields_Mappings.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public Fields_Mapping Find(int Key)
        {
            return db.Fields_Mappings.Find(Key) ?? null;
        }

        public IList<Fields_Mapping> getAll()
        {
            return db.Fields_Mappings.ToList();
        }

        public void update(Fields_Mapping oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}

