namespace MinimalAPIDemo;

public static class UserAPI
{
	public static void ConfigureApi(this WebApplication app)
	{
		app.MapGet("/api/users",GetUsers);
		app.MapGet("/api/users/{id}", GetUser);
        app.MapPost("/api/users", InsertUser);
        app.MapPut("/api/users", UpdateUser);
        app.MapDelete("/api/users/{id}",DeleteUser);
	}

	private static async Task<IResult> GetUsers(IUserData data)
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

    private static async Task<IResult> GetUser(IUserData data, int id)
    {
        try
        {
			var results = await data.GetUser(id);
			if(results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertUser(IUserData data,UserModel user)
    {
        try
        {
            await data.InsertUser(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUser(IUserData data, UserModel user)
    {
        try
        {
            await data.UpdateUser(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteUser(IUserData data, int id)
    {
        try
        {
            await data.DeleteUser(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
