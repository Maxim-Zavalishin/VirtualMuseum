namespace VirtualMuseum.Domain.Dto.User;

public record RegisterUserDto(
    string Firstname,
    string? Secondname,
    string Lastname,
    string Email,
    string Login,
    string Password,
    bool Mailing
    );