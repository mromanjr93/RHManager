using RHManager.Domain.Interfaces.Repositories;
using RHManager.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHManager.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private IRepositoryBase<TEntity> _repositoty;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repositoty = repository;
        }
        public void Add(TEntity obj)
        {
            _repositoty.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _repositoty.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repositoty.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repositoty.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repositoty.Remove(obj);
        }

        public void Dispose()
        {
            _repositoty.Dispose();
        }
    }
}
