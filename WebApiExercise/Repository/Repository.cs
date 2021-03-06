﻿using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace WebApiExercise.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _objectSet;

        public Repository(DbContext dbContext)
        {
            _objectSet = dbContext.Set<T>();
        }

        public IQueryable<T> LookupAll()
        {
            return _objectSet;
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return _objectSet.Where(filter);
        }

        public T GetSingle(Expression<Func<T, bool>> filter)
        {
            return _objectSet.SingleOrDefault(filter);
        }

        public void Create(T entity)
        {
            _objectSet.Add(entity);
        }

        public void Remove(T entity)
        {
            _objectSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _objectSet.AddOrUpdate(entity);
        }
    }
}