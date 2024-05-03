using VirtualMuseum.Domain.Interfaces;

namespace VirtualMuseum.Domain.Entity;

/// <summary>
/// Токен пользователя.
/// </summary>
public class UserToken : IBaseEntity<int>
{
    /// <inheritdoc />
    public int Id { get; set; }
    
    /// <summary>
    /// Refresh token.
    /// </summary>
    public string RefreshToken { get; set; }

    /// <summary>
    /// Время жизни токена.
    /// </summary>
    public DateTime RefreshTokenExpiryTime { get; set; }

    /// <summary>
    /// Пользователь.
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public int? UserId { get; set; }
}