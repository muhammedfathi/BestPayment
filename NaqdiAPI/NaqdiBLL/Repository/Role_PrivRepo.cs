using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.Rol_PrivFT.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public Rol_PrivFT Find(int Key)
        {
            return db.Rol_PrivFT.Find(Key) ?? null;
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


