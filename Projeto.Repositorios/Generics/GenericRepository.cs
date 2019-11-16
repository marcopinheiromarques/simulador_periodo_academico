using Projeto.Repositorios.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repositorios.Generics
{
    public class GenericRepository<T> where T : class
    {
        public virtual void Insert(T obj)
        {
            using (DataContext ctx = new DataContext())
            {
                ctx.Entry(obj).State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public virtual void Update(T obj)
        {
            using (DataContext ctx = new DataContext())
            {
                ctx.Entry(obj).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public virtual void Delete(T obj)
        {
            using (DataContext ctx = new DataContext())
            {
                ctx.Entry(obj).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public virtual List<T> FindAll()
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Set<T>().ToList();
            }
        }

        public virtual T FindById(int id)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Set<T>().Find(id);
            }
        }
    }
}
