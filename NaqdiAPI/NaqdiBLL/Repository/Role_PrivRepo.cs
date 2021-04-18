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
    public class Role_PrivRepo : BestPaymentRepo<Rol_PrivFT>
    {
        private NakqdiAppContext db;

        public Role_PrivRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }

        public void add(Rol_PrivFT newEntity)
        {
            db.Rol_PrivFT.Add(newEntity);
            db.SaveChanges();
        }

        public IList<Rol_PrivFT> FindByCondition(Expression<Func<Rol_PrivFT, bool>> expression)
        {
            return db.Rol_PrivFT.Where(expression).ToList();
        }

        public void Delet(Rol_PrivFT Entity)
        {
            db.Rol_PrivFT.Remove(Entity);
            db.SaveChanges();
        }

        public IList<Rol_PrivFT> getAll()
        {
            return db.Rol_PrivFT.ToList();
        }

        public void update(Rol_PrivFT oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }


    }
}


