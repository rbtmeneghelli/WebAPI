using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.Infra.Repositories.Configuration;

public class EmailDisplayRepository : IEmailDisplayRepository
{
    private readonly IGenericRepository<EmailDisplay> _iEmailDisplayRepository;

    public EmailDisplayRepository(IGenericRepository<EmailDisplay> iEmailDisplayRepository)
    {
        _iEmailDisplayRepository = iEmailDisplayRepository;
    }
}
