using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppLibrary.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DbContext db;
        DbSet<T> dbSet;
        public Repository(DbContext db)
        {
            this.db = db;
            dbSet = db.Set<T>();
        }

        public bool Create(T item)
        {
            if (item is null)
                return false;
            try
            {
                db.Add(item);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: ", e.Message);
                return false;
            }
            db.SaveChanges();
            return true;
        }


        public T Find(Func<T, bool> predicate)
        {
            return dbSet.FirstOrDefault(t => t.Equals(predicate));
        }

        public T Find(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }
        public IEnumerable<T> GetAllWithInclude(params string[] parameters)
        {
            var res = new List<T>();
            foreach (var param in parameters)
            {
                var temp = dbSet.Include(param);
                res.AddRange(temp);
            }
            return res.Distinct();
        }
        public bool Remove(T item)
        {
            try
            {
                dbSet.Remove(item);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: ", e.Message);
                return false;
            }
            db.SaveChanges();
            return true;
        }

        public bool Update(T item)
        {
            try
            {
                dbSet.Update(item);
                //var item = dbSet.TodoItems.Attach(changedItem);
                //item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: ", e.Message);
                return false;
            }
            db.SaveChanges();
            return true;
        }
    }
}
