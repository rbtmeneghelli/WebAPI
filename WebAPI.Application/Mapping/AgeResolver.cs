using AutoMapper;
using WebAPI.Domain.DTO.ControlPanel;
using WebAPI.Domain.Entities.ControlPanel;

public class AgeResolver : IValueResolver<Employee, EmployeeResponseDTO, int>
{
  public int Resolve(Employee source, EmployeeResponseDTO destination, int destMember, ResolutionContext context)
  {
    var today = DateTime.Today;
    int age = today.Year - source.BirthDate.Year;
    if(source.BirthDate.Date > today.AddYears(-age))
      age--;

    return age;
  }
}
