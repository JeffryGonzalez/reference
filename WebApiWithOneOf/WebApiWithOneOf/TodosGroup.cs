namespace WebApiWithOneOf;

public static class TodosGroup
{
    public static RouteGroupBuilder MapTodosApi(this RouteGroupBuilder group)
    {
        group.MapGet("/");
        return group;
    }

    public static async Task<>
}
