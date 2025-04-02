﻿namespace Payment_Persistence;
public interface IRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity order);
    Task<TEntity?> GetByIdAsync(Guid id);
    void Update(TEntity order);
    void Remove(TEntity order);
}

