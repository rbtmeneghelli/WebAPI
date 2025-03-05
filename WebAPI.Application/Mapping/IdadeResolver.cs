using AutoMapper;
using System;

public class IdadeResolver : IValueResolver<Employee, EmployeeDTO, int>
{
  public int Resolve(Employee source, EmployeeDTO destination, int destMember, ResolutionContext context)
  {
    var today = DateTime.Today;
    int age = today.Year - source.BirthDate.Year;
    if(source.BirthDate.Year > today.AddYears(-age))
      age--;

    return age;
  }
}
