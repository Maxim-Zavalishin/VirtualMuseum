using VirtualMuseum.Domain.Dto.Position;

namespace VirtualMuseum.Domain.Dto.Author;

public record CreateAuthorDto(
    string Firstname,
    string? Secondname,
    string Lastname,
    List<PositionDto> Positions
    );