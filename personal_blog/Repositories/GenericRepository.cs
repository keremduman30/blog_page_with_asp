using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using personal_blog.Models.Entity;

namespace personal_blog.Repositories
{
    //bu sınıfın amacı tekrarlı yapıları surekli olarka yazmamak 
    public class GenericRepository<T> where T:class,new()
    {
        DbCvEntities db = new DbCvEntities();
        public List<T> List() {
            return db.Set<T>().ToList();

        }
        public void Tadd(T p) {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public T Tget(int id) {
          return  db.Set<T>().Find(id);
        }
        public void TDelete(T t)
        {
             db.Set<T>().Remove(t);
            db.SaveChanges();
        }
        public void Tupdate(T p) {
            db.SaveChanges();
        }
        public T find(Expression<Func<T, bool>> where) {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}