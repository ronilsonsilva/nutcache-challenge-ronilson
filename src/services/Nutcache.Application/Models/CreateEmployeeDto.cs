using Nutcache.Domain.Entities;

namespace Nutcache.Application.Models
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public Team? Team { get; set; }
    }
}
