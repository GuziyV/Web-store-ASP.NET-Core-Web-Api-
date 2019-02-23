using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICRUDService<TEntity, TEntityDTO>
        where TEntity : IEntity
        where TEntityDTO : class
    {
        Task<List<TEntityDTO>> GetAllAsync();
        Task<TEntityDTO> GetOneAsync(int identifier);
        Task<TEntityDTO> UpdateAsync(TEntityDTO entity);
        Task<bool> TryDeleteAsync(int identifier);
        Task<TEntityDTO> PostAsync(TEntityDTO entity);
    }
}
