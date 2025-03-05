using AutoMapper;
using WebAPI.Domain.DTO.ControlPanel;
using WebAPI.Domain.Entities.ControlPanel;

public class AnualSalaryResolver : IValueResolver<Employee, EmployeeResponseDTO, decimal>
{
  public decimal Resolve(Employee source, EmployeeResponseDTO destination, decimal destMember, ResolutionContext context)
  {
    return source.Salary * 12;
  }
}
