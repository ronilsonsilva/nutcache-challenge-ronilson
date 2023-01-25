using AutoMapper;
using Nutcache.Application.Contracts;
using Nutcache.Application.Models;
using Nutcache.Domain.Contracts.DomainServices;
using Nutcache.Domain.DomainResponse;
using Nutcache.Employee.Domain.Entities;

namespace Nutcache.Application.Services
{
    public class ApplicationServices<TEntity, TEntityDto, CreateDto, UpdateDto, ListDto> : IApplicationServices<TEntityDto, CreateDto, UpdateDto, ListDto> where TEntityDto : BaseDto where TEntity : EntityBase where CreateDto : class where UpdateDto : class where ListDto : class
    {
        protected readonly IMapper _mapper;
        protected readonly IDomainServices<TEntity> _service;

        public ApplicationServices(IMapper mapper, IDomainServices<TEntity> service)
        {
            _mapper = mapper;
            _service = service;
        }

        public virtual async Task<Response<TEntityDto>> Add(CreateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var response = await _service.Add(entity);
            return response.Map<TEntityDto>(_mapper);
        }

        public virtual async Task<TEntityDto> Get(int id)
        {
            var entity = await _service.Get(id);
            return _mapper.Map<TEntityDto>(entity);
        }

        public virtual async Task<IList<ListDto>> Get()
        {
            var entities = await _service.Get();
            return _mapper.Map<IList<ListDto>>(entities);
        }

        public virtual async Task<Response<bool>> Delete(int id)
        {
            return await _service.Delete(id);
        }

        public virtual async Task<Response<TEntityDto>> Update(UpdateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var response = await _service.Update(entity);
            return response.Map<TEntityDto>(_mapper);
        }
    }
}
