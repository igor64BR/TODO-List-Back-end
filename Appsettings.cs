using static TodoListBackend.Appsettings;

namespace TodoListBackend
{
    public partial record Appsettings(
         JwtSettings Jwt,
         ConnectionStringsSettings ConnectionStrings);
}
