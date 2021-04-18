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


        public IList<Fields_Mapping> FindByCondition(Expression<Func<Fields_Mapping, bool>> expression)
        {
            return db.Fields_Mappings.Where(expression).ToList();
        }

        public void Delet(Fields_Mapping Entity)
        {
            db.Fields_Mappings.Remove(Entity);
            db.SaveChanges();
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

