using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaqdiBLL.Repository
{

    public class CasesCPSFieldRepo: BestPaymentRepo<CasesCPSField_Prov>
    {
        private NakqdiAppContext db;

        public CasesCPSFieldRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }




        public void add(CasesCPSField_Prov newEntity)
        {
            db.CasesCPSField_Provs.Add(newEntity);
            db.SaveChanges();
        }

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.CasesCPSField_Provs.Remove(Find(id));
                db.SaveChanges();

            }
        }

        public CasesCPSField_Prov Find(int Key)
        {
            return db.CasesCPSField_Provs.Find(Key) ?? null;
        }

        public IList<CasesCPSField_Prov> getAll()
        {
            return db.CasesCPSField_Provs.ToList();
        }

        public void update(CasesCPSField_Prov oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
