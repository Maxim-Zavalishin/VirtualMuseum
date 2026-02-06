using Microsoft.AspNetCore.Mvc;
using VirtualMuseum.Domain.Dto.User;
using VirtualMuseum.Domain.Dto.UserToken;
using VirtualMuseum.Domain.Interfaces.Services;
using VirtualMuseum.Domain.Result;

namespace VirtualMuseum.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Регистрация пользователя.
    /// </summary>
    /// <param name="dto"> Данные для регистрации. </param>
    /// <returns> Результат регистрации. </returns>
    [HttpPost("register")]
    public async Task<ActionResult<BaseResult<UserDto>>> Register([FromBody] RegisterUserDto dto)
    {
        var response = await _authService.Register(dto);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }
    
    /// <summary>
    /// Авторизация пользователя.
    /// </summary>
    /// <param name="dto"> Данные для авторизации. </param>
    /// <returns> Jwt-токены (Access и Refresh).  </returns>
    [HttpPost("login")]
    public async Task<ActionResult<BaseResult<TokenDto>>> Login([FromBody] LoginActorDto dto)
    {
        var response = await _authService.Login(dto);

        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(Response);
    }
}