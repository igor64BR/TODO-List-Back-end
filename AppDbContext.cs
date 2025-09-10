using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoListBackend.Entities;

namespace TodoListBackend
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
            : IdentityDbContext<IdentityUser>(options)
    {
        public DbSet<Todo> Todos => Set<Todo>();
    }
}
