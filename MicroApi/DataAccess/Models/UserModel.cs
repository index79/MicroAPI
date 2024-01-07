namespace DataAccess.Models;

public class UserModel
{
    public int UserId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}