﻿using DAL.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IFRepositorio : IRepository
    {
        //Llmada  a la clase de conetxto
        ApplicationDbContext _context;
        //Dispose
        private bool disposedValue;

        public async Task<TEntity> CreateAsync<TEntity>(TEntity toCreate) where TEntity : class 
        {
            TEntity Result = default(TEntity);
            try
            {
                await _context.Set<TEntity>().AddAsync(toCreate);
                await _context.SaveChangesAsync();
                Result = toCreate;
            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }
        
        public Task<bool> DeleteAsync<TEntity>(TEntity toDelete) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> FilterAsync<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> RetreiveAsync<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync<TEntity>(TEntity toUpdate) where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}
