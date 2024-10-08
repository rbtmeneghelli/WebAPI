﻿using System.Linq.Expressions;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.Domain.Interfaces.Repository;

public interface ILogRepository
{
    IQueryable<Log> GetAll(bool hasTracking = false);
    Log GetById(long id);
    IQueryable<Log> FindBy(Expression<Func<Log, bool>> predicate, bool hasTracking = false);
    bool Exist(Expression<Func<Log, bool>> predicate);
}
