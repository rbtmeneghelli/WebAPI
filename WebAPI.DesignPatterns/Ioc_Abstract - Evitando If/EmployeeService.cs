using WebAPI.DesignPatterns.Ioc_Abstract.Entities;
using System.Net;

namespace WebAPI.DesignPatterns.Ioc_Abstract;

public class EmployeeService : BaseJobService<Employee>
{
    public EmployeeService(IJobService jobService) :
    base(jobService)
    {
    }

    public override decimal CalculateSalary(Employee entity)
    {
        throw new NotImplementedException();
    }
}