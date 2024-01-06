using appmedic.Domain.Dtos;
using appmedic.Domain.Entities;
using AutoMapper;

namespace appmedic.Domain.Mapper;

public class EntityToDto:Profile
{
    public EntityToDto()
    {
        CreateMap<User, UserDto>();
    }
}