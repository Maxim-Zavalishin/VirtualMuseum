using AutoMapper;
using VirtualMuseum.Domain.Entity;
using VirtualMuseum.Domain.Dto.User;

namespace VirtualMuseum.Application.AutoMapper.UserMapper;

public class UserRegisterMapper : Profile
{
    public UserRegisterMapper()
    {
        CreateMap<User, RegisterUserDto>().ReverseMap();
    }
}