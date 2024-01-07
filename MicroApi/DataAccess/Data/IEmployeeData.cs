using DataAccess.DbAceess;
using DataAccess.Dtos;
using DataAccess.Models;

namespace DataAccess.Data;

public interface IEmployeeData
{
    Task<IEnumerable<EmployeeData>> GetEmployees();
    Task<EmployeeData?> GetEmployee(int EmployeeId);
    Task InsertEmployee(EmployeeDto employee);
    Task UpdateEmployee(EmployeeData employee);
    Task DeleteEmployee(int employeeId);
}