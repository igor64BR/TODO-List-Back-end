namespace TodoListBackend.Endpoints
{
    public static class WebApplicationExtension
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapTodoEndpoints();
            app.MapUserEndpoints();
        }
    }
}
