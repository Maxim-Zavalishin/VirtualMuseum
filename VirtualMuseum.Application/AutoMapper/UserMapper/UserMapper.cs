using AutoMapper;
using VirtualMuseum.Domain.Dto.User;
using VirtualMuseum.Domain.Entity;

namespace VirtualMuseum.Application.AutoMapper.UserMapper;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}