using FluentValidation.Results;
using Nutcache.Domain.EntitiesValidators;
using Nutcache.Employee.Domain.Entities;

namespace Nutcache.Domain.Entities
{
    public class Employee : EntityBase
    {
        private Employee() { }

        public Employee(string name, DateTime birthDate, Gender gender, string email, DateTime startDate)
        {
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
            Email = email;
            StartDate = startDate;
        }

        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }
        public string Email { get; private set; }
        public DateTime StartDate { get; private set; }
        public Team? Team { get; private set; }

        public override ValidationResult Validate() => new EmployeeValidator().Validate(this);
    }
}
