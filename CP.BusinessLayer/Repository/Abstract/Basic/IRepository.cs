﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Repository.Abstract.Basic
{
    /// <summary>
    ///  * General Methods<br></br>
    ///  * T is Class Example : User
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class, new()
    {
        T GetById(int id);
        T GetByFilter(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id);
        List<T> GetAll(Expression<Func<T, object>> expression = null, Expression<Func<T, bool>> condition = null);
        List<T> GetFilterAll(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetFilterAllAsync(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Remove(int id);
        void Update(T entity);
        void Remove(T entity);
        void AddRange(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);
        int SqlFilterQuery(string query);
        Task<bool> IsThere(Expression<Func<T, bool>> expression);
        bool IsThereResult(Expression<Func<T, bool>> expression);
    }
}
