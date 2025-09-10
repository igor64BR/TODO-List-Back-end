using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListBackend.Entities
{
    [Table(nameof(Todo))]
    public partial class Todo
    {
        public Todo()
        {
            Name = string.Empty;
            User = null!;
            IsComplete = new(false);
            IsDeleted = new(false);
        }

        public int Id { get; set; }

        [MinLength(5), MaxLength(100)]
        public string Name { get; set; }

        public Bool IsComplete { get; private set; }
        public Bool IsDeleted { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }

        public IdentityUser User { get; set; }
    }
}
