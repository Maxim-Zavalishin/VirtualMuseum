using VirtualMuseum.Domain.Dto.User;
using VirtualMuseum.Domain.Dto.UserToken;
using VirtualMuseum.Domain.Result;

namespace VirtualMuseum.Domain.Interfaces.Services;

/// <summary>
/// Сервис для регистрации/авторизации пользователей.
/// </summary>
public interface IAuthServices
{
    /// <summary>
    /// Регистрация пользователя.
    /// </summary>
    /// <param name="dto"> Данные для создания пользователя. </param>
    /// <returns> true, при успешной регистрации, false — при ошибке. </returns>
    Task<BaseResult<UserDto>> Register(RegisterUserDto dto);
    
    /// <summary>
    /// Авторизация пользователя.
    /// </summary>
    /// <param name="dto"> Данные для входа (Логин и пароль). </param>
    /// <returns> Access и Refresh токены. </returns>
    Task<BaseResult<TokenDto>> Login(LoginActorDto dto);
}