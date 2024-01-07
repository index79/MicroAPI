using DataAccess.Data;
using DataAccess.Dtos;
using DataAccess.Models;

namespace MicroApi;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/Users", GetUsers);
        app.MapGet("/Users/{id}", GetUser);
        app.MapPost("/Users", InsertUser);
        app.MapPut("/Users", UpdateUser);
        app.MapDelete("/Users/{id}", DeleteUser);
    }

    public static async Task<IResult> GetUsers(IUserData data)
    {
        try
        {
            return Results.Ok(await data.GetUsers());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> GetUser(IUserData data, int id)
    {
        try
        {
            var results = Results.Ok(await data.GetUser(id));
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (System.Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> InsertUser(IUserData data, UserDto user)
    {
        try
        {
            await data.InsertUser(user);
            return Results.Ok();
        }
        catch (System.Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> UpdateUser(IUserData data, UserModel user)
    {
        try
        {
            await data.UpdataUser(user);
            return Results.Ok();
        }
        catch (System.Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> DeleteUser(IUserData data, int id)
    {
        try
        {
            await data.DeleteUser(id);
            return Results.Ok();
        }
        catch (System.Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}

