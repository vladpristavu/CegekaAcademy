using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema1
{
    public interface IRepository
    {
        void Insert<T>(T item) where T : class;

        void Remove<T>(T item) where T : class;
        bool Contains<T>(T item) where T : class;
         
        void Set<T>(T item) where T : class;
        Set<T> Merge(Set<T> other);

       
    }
}