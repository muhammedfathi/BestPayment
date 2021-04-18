using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NaqdiBLL.IRepository
{
    public interface BestPaymentRepo<T>
    {

        public void add(T newEntity);

        public IList< T> getAll();

        public void update(T oldEntity);

        public void Delet(T Entity);
        IList<T> FindByCondition(Expression<Func<T, bool>> expression);


    }
}
