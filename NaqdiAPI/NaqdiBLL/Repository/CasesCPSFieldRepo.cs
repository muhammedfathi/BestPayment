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

        public IList<CasesCPSField_Prov> FindByCondition(Expression<Func<CasesCPSField_Prov, bool>> expression)
        {
            return db.CasesCPSField_Provs.Where(expression).ToList();
        }

        public void Delet(CasesCPSField_Prov Entity)
        {
            db.CasesCPSField_Provs.Remove(Entity);
            db.SaveChanges();
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
