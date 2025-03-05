using AutoMapper;
using System;

public class AnualSalaryResolver : IValueResolver<Employee, EmployeeDTO, decimal>
{
  public decimal Resolve(Employee source, EmployeeDTO destination, decimal destMember, ResolutionContext context)
  {
    return source.Salary * 12;
  }
}
