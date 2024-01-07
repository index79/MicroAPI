using DataAccess.DbAceess;
using DataAccess.Dtos;
using DataAccess.Models;

namespace DataAccess.Data;

public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;

    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<UserModel>> GetUsers() =>
        await _db
            .LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });

    public async Task<UserModel?> GetUser(int id)
    {
        var result = await _db
           .LoadData<UserModel, dynamic>("dbo.spUser_Get", new { UserId = id });
        return result.FirstOrDefault();
    }

    public Task InsertUser(UserDto user) =>
        _db.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LastName });

    public Task UpdataUser(UserModel user) =>
        _db.SaveData("dbo.spUser_Update", user);

    public Task DeleteUser(int id) =>
        _db.SaveData("dbo.spUser_Delete", new { UserId = id });
}