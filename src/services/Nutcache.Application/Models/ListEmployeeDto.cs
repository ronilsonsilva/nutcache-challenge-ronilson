using Nutcache.Domain.Entities;

namespace Nutcache.Application.Models
{
    public class ListEmployeeDto : EmployeeDto
    {
        public string TeamDescription => Enum.GetName(typeof(Team),this.Team);
    }
}
