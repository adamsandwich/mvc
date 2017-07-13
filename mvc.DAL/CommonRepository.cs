using mvc.IDAL;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.DAL
{
    public abstract class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        DBContainer db;
        public CommonRepository(DBContainer context)
        {
            this.db = context;
        }

        public DBContainer Context
        {
            get { return db; }
        }

        public virtual bool Create(T model)
        {
            db.Set<T>().Add(model);
            return db.SaveChanges() > 0;
        }

        public virtual bool Edit(T model)
        {
            if (db.Entry<T>(model).State == EntityState.Modified)
            {
                return db.SaveChanges() > 0;
            }
            else if (db.Entry<T>(model).State == EntityState.Detached)
            {
                try
                {
                    db.Set<T>().Attach(model);
                    db.Entry<T>(model).State = EntityState.Modified;
                }
                catch (InvalidOperationException)
                {
                    //T old = Find(model._ID);
                    //db.Entry<old>.CurrentValues.SetValues(model);
                }
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public virtual bool Delete(T model)
        {
            db.Set<T>().Remove(model);
            return db.SaveChanges() > 0;
        }

        public virtual int Delete(params object[] keyValues)
        {
            T model = GetById(keyValues);
            if (model != null)
            {
                db.Set<T>().Remove(model);
                return db.SaveChanges();
            }
            return -1;
        }
        public virtual T GetById(params object[] keyValues)
        {
            return db.Set<T>().Find(keyValues);
        }

        public virtual IQueryable<T> GetList()
        {
            return db.Set<T>();
        }

        public virtual IQueryable<T> GetList(Func<T, bool> whereLambda)
        {
            return db.Set<T>().Where(whereLambda).AsQueryable();
        }
        public virtual bool IsExist(string id)
        {
            return GetById(id) != null;
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
