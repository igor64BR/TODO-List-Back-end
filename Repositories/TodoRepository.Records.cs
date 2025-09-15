using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using TodoListBackend.Entities;

namespace TodoListBackend.Services
{
    public partial class TodoRepository
    {
        public record CreateDto(string Name, IdentityUser User)
        {
            public Todo ToModel() => new(Name, User);
        }

        public record ListDto(int Id, string Name, bool IsCompleted)
        {
            public static ListDto FromModel(Todo todo)
            {
                var isDeleted = todo.IsDeleted.Value;

                if (isDeleted)
                    throw new Exception("Cannot convert a deleted todo to ListDto.");

                return Selector
                    .Compile()
                    .Invoke(todo);
            }

            public static Expression<Func<Todo, ListDto>> Selector => todo => new ListDto(
                todo.Id,
                todo.Name,
                todo.IsComplete.Value);
        }

        public record UpdateDto(int Id, string Name);
        public record DeleteDto(int Id);
    }
}
