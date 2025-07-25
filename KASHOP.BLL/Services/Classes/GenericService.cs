using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repositories.Classes;
using KASHOP.DAL.Repositories.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Services.Classes
{
    public class GenericService<TRequest, TResponse, TEntity> : IGenericService<TRequest, TResponse, TEntity>
        where TEntity : BaseModel
    {
        private readonly iGenericRepository<TEntity> repository;

        public GenericService(iGenericRepository<TEntity> repository)
        {
            this.repository = repository;
        }
        public int Create(TRequest request)
        {
            var entity = request.Adapt<TEntity>();
            return repository.Add(entity);
        }

        public int Delete(int id)
        {
            var entity = repository.GetById(id);
            if (entity is null)
            {
                return 0;
            }
            return repository.Remove(entity);
        }

        public IEnumerable<TResponse> GetAll()
        {
            var entities = repository.GetAll();
            return entities.Adapt<IEnumerable<TResponse>>();
        }

        public TResponse GetById(int id)
        {
            var entity = repository.GetById(id);
            return entity is null ? default : entity.Adapt<TResponse>();
        }

        public bool ToggleStatus(int id)
        {
            var entity = repository.GetById(id);
            if (entity is null) return false;
            entity.Status = entity.Status == Status.Active ? Status.Inactive : Status.Active;
            repository.Update(entity);
            return true;
        }

        public int Update(int id, TRequest request)
        {
            var entity = repository.GetById(id);
            if (entity is null)
            {
                return 0;
            }
            //entity.Name = request.Name;
            var updatedEntity = request.Adapt(entity);
            return repository.Update(updatedEntity);
        }
    }
}
