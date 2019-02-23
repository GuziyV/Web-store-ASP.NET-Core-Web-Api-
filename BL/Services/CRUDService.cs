using AutoMapper;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class CRUDService<TEntity, TEntityDTO> : ICRUDService<TEntity, TEntityDTO>
        where TEntity : class, IEntity
        where TEntityDTO : class
    {
        protected readonly DbContext context;
        protected readonly IMapper mapper;

        public CRUDService(DbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public virtual async Task<List<TEntityDTO>> GetAllAsync()
        {
            return context != null ?
                mapper.Map<List<TEntityDTO>>(await context.Set<TEntity>().ToListAsync()) :
                null;
        }

        public virtual async Task<TEntityDTO> GetOneAsync(int identifier)
        {
            return context != null ? 
                mapper.Map<TEntityDTO>(await context.Set<TEntity>().FindAsync(identifier)) :
                null;
        }

        public virtual async Task<TEntityDTO> PostAsync(TEntityDTO entity)
        {
            var resEntity = context != null ?
                (await context.AddAsync<TEntity>(mapper.Map<TEntity>(entity))).Entity :
                null;
            context.SaveChanges();
            return mapper.Map<TEntityDTO>(resEntity);
        }

        public virtual async Task<TEntityDTO> UpdateAsync(TEntityDTO entity)
        {
            var resEntity = context != null ?
                context.Update<TEntity>(mapper.Map<TEntity>(entity)).Entity :
                null;
            await context.SaveChangesAsync();
            return mapper.Map<TEntityDTO>(resEntity);
        }

        public virtual async Task<bool> TryDeleteAsync(int identifier)
        {
            if(context != null)
            {
                var entity = context.Find<TEntity>(identifier);
                if(entity != null)
                {
                    context.Remove<TEntity>(entity);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
    }
}
