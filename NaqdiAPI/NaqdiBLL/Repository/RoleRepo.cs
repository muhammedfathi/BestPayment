using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.Role.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public Role Find(int Key)
        {
            return db.Role.Find(Key) ?? null;
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


