﻿using BeckTech.Core.Entities;
using BeckTech.Data.Context;
using BeckTech.Data.Repositories.Abtractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Data.Repositories.Concretes
{
    public class Repository<T>: IRepository<T> where T : class, IEntityBase ,new()
    {
        private readonly BeckTechDbContext dbContext;

        public Repository(BeckTechDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> Table { get => dbContext.Set<T>(); }
        public async Task<List<T>> GetAllAsync(Expression<Func<T,bool>> predicate =null,params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
                query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.ToListAsync();
        }
    
    
        public async Task AddAsycn(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate , params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.SingleAsync(); 
        }

        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> UpdateAsycn(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }

        public async Task DeleteAsycn(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
            
        }

        public async Task<bool> AnyAsycn(Expression<Func<T, bool>> predicate)
        {
            return await Table.AllAsync(predicate);
        }

        public async Task<int> CountAsycn(Expression<Func<T, bool>> predicate = null)
        {
            return await Table.CountAsync(predicate);
        }
    }
}
