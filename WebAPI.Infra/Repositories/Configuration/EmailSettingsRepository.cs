using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.Infra.Repositories.Configuration;

public class EmailSettingsRepository : IEmailSettingsRepository
{
    private readonly IGenericRepository<EmailSettings> _iEmailSettingsRepository;

    public EmailSettingsRepository(IGenericRepository<EmailSettings> iEmailSettingsRepository)
    {
        _iEmailSettingsRepository = iEmailSettingsRepository;
    }
}
