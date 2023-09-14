using Azure;
using Infrastructure.DBContext;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly DbSet<T> _entity;

        public Repository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
            _entity = dBContext.Set<T>();
        }

        public async Task<ProcessResponse<T>> Create(T entity)
        {
            ProcessResponse<T> response = new ProcessResponse<T>();
            try
            {
                var result = await _entity.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                response.Data = entity; ;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
            }

            return response;
        }

        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ProcessResponse<T>> GetById(int id)
        {
            ProcessResponse<T> response = new ProcessResponse<T>();
            try
            {
                var item = await _entity.FindAsync(id);
                if(item != null)
                {
                    response.Data = item;
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
            }

            return response;
        }

        public async Task<ProcessResponse<T>> Update(T entity)
        {
            ProcessResponse<T> response = new ProcessResponse<T>();

            try
            {
                var entityToUpdate = await _entity.FindAsync(entity);
                if(entityToUpdate != null)
                {
                    entityToUpdate = entity;
                    await _dbContext.SaveChangesAsync();
                    response.Data = entity;
                }
                else
                {
                    response.Success = false;
                    response.Error = "Entity not found";
                }
            }
            catch(Exception ex)  
            {
                response.Success = false; 
                response.Error = ex.Message;
            }

            return response;
        }
    }
}
