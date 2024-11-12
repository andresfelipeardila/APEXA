using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApexaApp.API.Data.Repositories;
using ApexaApp.API.Models;

namespace ApexaApp.API.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity: BaseEntity;
        Task<bool> Complete();
    }
}