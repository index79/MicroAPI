using DataAccess.DbAceess;
using DataAccess.Dtos;
using DataAccess.Models;

namespace DataAccess.Data;

public class EmployeeData : IEmployeeData
{
    private readonly ISqlDataAccess _db;

    public EmployeeData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<EmployeeData>> GetEmployees() =>
        await _db.LoadData<EmployeeData, dynamic>("dbo.spEmployee_getEmployees", new { });

    public async Task<EmployeeData?> GetEmployee(int EmployeeId)
    {
        var results = await _db.LoadData<EmployeeData, dynamic>
            ("dbo.spEmployee_getEmployee", new { EmployeeId });

        return results.FirstOrDefault();
    }

    public async Task InsertEmployee(EmployeeDto employee) =>
        await _db.SaveData("dbo.spEmployee_InsertEmployee", new { employee.UserId, employee.Designation });

    public async Task UpdateEmployee(EmployeeData employee) =>
        await _db.SaveData("dbo.spEmployee_UpdateEmployee", employee);

    public async Task DeleteEmployee(int employeeId) =>
        await _db.SaveData("dbo.spEmployee_DeleteEmployee", new { EmployeedId = employeeId });

}