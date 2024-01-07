using DataAccess.Dtos;
using DataAccess.Models;

namespace DataAccess.Data;

public interface IUserData
{
    Task<IEnumerable<UserModel>> GetUsers();
    Task<UserModel?> GetUser(int id);
    Task InsertUser(UserDto user);
    Task UpdataUser(UserModel user);
    Task DeleteUser(int id);
}