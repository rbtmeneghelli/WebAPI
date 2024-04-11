using WebAPI.DesignPatterns.Ioc_Abstract.Entities;

namespace WebAPI.DesignPatterns.Ioc_Abstract;

public class BossService : BaseJobService<Boss>
{
    public BossService(IJobService jobService) :
    base(jobService)
    {
    }

    public override decimal CalculateSalary(Boss entity)
    {
        throw new NotImplementedException();
    }
}
