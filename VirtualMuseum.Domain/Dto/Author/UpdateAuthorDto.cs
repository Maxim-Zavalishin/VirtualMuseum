using VirtualMuseum.Domain.Dto.Position;

namespace VirtualMuseum.Domain.Dto.Author;

public record UpdateAuthorDto(  
    string Firstname,
    string? Secondname,
    string Lastname,
    List<PositionDto> Positions
    );