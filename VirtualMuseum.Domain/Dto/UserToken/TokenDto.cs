namespace VirtualMuseum.Domain.Dto.UserToken;

public record TokenDto(
    string AccessToken, 
    string RefreshToken, 
    int Id
    );