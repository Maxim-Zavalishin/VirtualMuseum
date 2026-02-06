namespace VirtualMuseum.Domain.Dto.User;

public record UserDto(
    string Firstname,
    string? Secondname,
    string Lastname,
    string Email,
    string Login,
    bool Mailing
    );