﻿using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.InfraStructure.Data.Repositories.Configuration;

public class LogSettingsRepository : ILogSettingsRepository
{
    private readonly IGenericReadRepository<LogSettings> _iLogSettingsReadRepository;
    private readonly IGenericWriteRepository<LogSettings> _iLogSettingsWriteRepository;

    public LogSettingsRepository(
        IGenericReadRepository<LogSettings> iLogSettingsReadRepository,
        IGenericWriteRepository<LogSettings> iLogSettingsWriteRepository)
    {
        _iLogSettingsReadRepository = iLogSettingsReadRepository;
        _iLogSettingsWriteRepository = iLogSettingsWriteRepository;
    }

    public IQueryable<LogSettings> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iLogSettingsReadRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<LogSettings> FindBy(Expression<Func<LogSettings, bool>> predicate, bool hasTracking = false)
    {
        return _iLogSettingsReadRepository.GetByPredicate(predicate, hasTracking);
    }

    public LogSettings GetById(long id)
    {
        return _iLogSettingsReadRepository.GetById(id);
    }

    public bool Exist(Expression<Func<LogSettings, bool>> predicate)
    {
        return _iLogSettingsReadRepository.Exist(predicate);
    }

    public void Create(LogSettings logSettings)
    {
        _iLogSettingsWriteRepository.Create(logSettings);
    }

    public void Update(LogSettings logSettings)
    {
        _iLogSettingsWriteRepository.Update(logSettings);
    }
}
