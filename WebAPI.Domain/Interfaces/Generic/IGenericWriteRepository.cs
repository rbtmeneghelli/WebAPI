﻿using System.Linq.Expressions;

namespace WebAPI.Domain.Interfaces.Generic;

public interface IGenericWriteRepository<TEntity> : IDisposable where TEntity : GenericEntityModel
{
    void Create(TEntity entity);
    void BulkCreate(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    void ExecuteDelete(Expression<Func<TEntity, bool>> predicate);
    /// <summary>
    /// EF Core -  Múltiplos Requests p/ um DataBase em uma Transação
    /// Referencia >> https://macoratti.net/22/11/efcore_multireqdb1.htm
    /// </summary>
    /// <param name="entity"></param>
    void AddTransaction(TEntity entity);
}
