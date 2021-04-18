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
    public class RoleRepo : BestPaymentRepo<Role>
    {

        private NakqdiAppContext db;

        public RoleRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }

        public void add(Role newEntity)
        {
            db.Role.Add(newEntity);
            db.SaveChanges();
        }

        public IList<Role> FindByCondition(Expression<Func<Role, bool>> expression)
        {
            return db.Role.Where(expression).ToList();
        }

        public void Delet(Role Entity)
        {
            db.Role.Remove(Entity);
            db.SaveChanges();
        }

        public IList<Role> getAll()
        {
            return db.Role.ToList();
        }

        public void update(Role oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}


