﻿using Amos.VTUCORE3._1.Models.Repo.Infrastructure.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.Repo.Infrastructure
{
    /// <summary>
    /// Base class for all SQL based service classes
    /// </summary>
    /// <typeparam name="T">The domain object type</typeparam>
    /// <typeparam name="TU">The database object type</typeparam>
    /// 
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        internal DbSet<T> dbSet;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            this.dbSet = _unitOfWork.Db.Set<T>();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> whereCondition)
        {
            var dbResult = dbSet.Where(whereCondition).FirstOrDefault();
            return dbResult;
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> whereCondition)
        {
            return dbSet.Where(whereCondition).AsEnumerable();
        }

        public virtual T Insert(T entity)
        {
            dynamic obj = dbSet.Add(entity);
            this._unitOfWork.Db.SaveChanges();
            return obj;

        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            this._unitOfWork.Db.SaveChanges();


        }

        public virtual void UpdateAll(IList<T> entities)
        {
            foreach (var entity in entities)
            {
                dbSet.Attach(entity);
                _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            }
            this._unitOfWork.Db.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> whereCondition)
        {
            IEnumerable<T> entities = this.GetAll(whereCondition);
            foreach (T entity in entities)
            {
                if (_unitOfWork.Db.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
            }
            this._unitOfWork.Db.SaveChanges();
        }

        public bool Exists(Expression<Func<T, bool>> whereCondition)
        {
            return dbSet.Any(whereCondition);
        }

    }
}

