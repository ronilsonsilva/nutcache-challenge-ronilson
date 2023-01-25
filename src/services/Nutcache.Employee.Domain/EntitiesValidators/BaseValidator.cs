using FluentValidation;
using Nutcache.Employee.Domain.Entities;

namespace Nutcache.Domain.EntitiesValidators
{
    public abstract class BaseValidator<TEntity> : AbstractValidator<TEntity> where TEntity : EntityBase
    {

    }
}
