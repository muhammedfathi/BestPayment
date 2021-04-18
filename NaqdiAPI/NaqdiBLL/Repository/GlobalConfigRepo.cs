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
    public class GlobalConfigRepo : BestPaymentRepo<GlobalConfigration>
    {

        private NakqdiAppContext db;

        public GlobalConfigRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }


        public void add(GlobalConfigration newEntity)
        {
            db.GlobalConfigration.Add(newEntity);
            db.SaveChanges();
        }

        public IList<GlobalConfigration> FindByCondition(Expression<Func<GlobalConfigration, bool>> expression)
        {
            return db.GlobalConfigration.Where(expression).ToList();
        }

        public void Delet(GlobalConfigration Entity)
        {
            db.GlobalConfigration.Remove(Entity);
            db.SaveChanges();
        }

        public IList<GlobalConfigration> getAll()
        {
            return db.GlobalConfigration.ToList();
        }

        public void update(GlobalConfigration oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}



