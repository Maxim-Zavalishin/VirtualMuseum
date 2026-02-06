using VirtualMuseum.Domain.Dto.Position;

namespace VirtualMuseum.Domain.Dto.Author;

public record AuthorDto(
    int Id,
    string Firstname,
    string? Secondname,
    string Lastname,
    int CountArticle,
    List<PositionDto>? Positions
);