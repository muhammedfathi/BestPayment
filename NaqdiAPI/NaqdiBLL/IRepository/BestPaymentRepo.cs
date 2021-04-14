using System;
using System.Collections.Generic;
using System.Text;

namespace NaqdiBLL.IRepository
{
    public interface BestPaymentRepo<T>
    {

        public void add(T newEntity);

        public IList< T> getAll();

        public void update(T oldEntity);

        public void Delet(int id);

        public T Find(int Key);//?


      

    }
}
