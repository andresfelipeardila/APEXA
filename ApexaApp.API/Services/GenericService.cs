
using ApexaApp.API.Data.Interfaces;
using ApexaApp.API.Data.Repositories;

using ApexaApp.API.Models;

namespace ApexaApp.API.Services
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly GenericRepository<T> _repository;
        public GenericService(GenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _repository.ListAllAsync();
        }

        public async Task<T?> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await _repository.GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await _repository.ListAsync(spec);
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await _repository.CountAsync(spec);
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void Update(T entity)
        {
           _repository.Update(entity);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }
    }
}