using VirtualMuseum.Domain.Dto.Article;
using VirtualMuseum.Domain.Dto.Position;

namespace VirtualMuseum.Domain.Dto.Author;

public record GetAuthorDto(
    int Id,
    string Firstname,
    string? Secondname,
    string Lastname,
    List<GetListArticleDto> Article,
    List<PositionDto>? Positions
    );