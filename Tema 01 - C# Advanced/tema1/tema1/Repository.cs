using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema1
{
    public class Repository : IRepository
    {
        public IRepository DbContext { get; set; }
        public bool Contains<T>(T item) where T : class
        {
            try
            {
                if (DbContext.Contains(item))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
        }

        public void Insert<T>(T item) where T : class
        {
            try
            {
                DbContext.Insert(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public Set<T> Merge(Set<T> other)
        {
            try
            {
                DbContext.Merge(other);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void Remove<T>(T item) where T : class
        {
            try 
            { 
                DbContext.Remove(item); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
