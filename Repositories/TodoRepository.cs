using Microsoft.EntityFrameworkCore;
using TodoListBackend.Entities;

namespace TodoListBackend.Services
{
    public interface ITodoRepository
    {
        void Create(TodoRepository.CreateDto dto);
        Task<List<TodoRepository.ListDto>> List();
        void Update(TodoRepository.UpdateDto dto);
        void Delete(TodoRepository.DeleteDto dto);
    }

    public partial class TodoRepository(AppDbContext context) : ITodoRepository
    {
        private readonly DbSet<Todo> _todosSet = context.Todos;

        public void Create(CreateDto dto)
        {
            if (_todosSet.Any(x => x.Name.Equals(dto.Name, StringComparison.CurrentCultureIgnoreCase)))
                throw new Exception("A todo with the same name already exists.");

            var todo = dto.ToModel();

            _todosSet.Add(todo);
        }

        public async Task<List<ListDto>> List() => await _todosSet
            .AsNoTracking()
            .Where(x => !x.IsDeleted.Value)
            .Select(ListDto.Selector)
            .ToListAsync();

        public void Delete(DeleteDto dto)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
