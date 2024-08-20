using AutoMapper;
using VirtualMuseum.Domain.Dto.Position;
using VirtualMuseum.Domain.Entity;

namespace VirtualMuseum.Application.AutoMapper.PositionMappers;

public class PositionMapper : Profile
{
    public PositionMapper()
    {
        CreateMap<Position, PositionDto>().ReverseMap();
    }
}