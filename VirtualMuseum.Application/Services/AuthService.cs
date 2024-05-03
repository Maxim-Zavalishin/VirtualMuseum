using System.Security.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualMuseum.Application.Helpers;
using VirtualMuseum.Domain.Dto.User;
using VirtualMuseum.Domain.Dto.UserToken;
using VirtualMuseum.Domain.Entity;
using VirtualMuseum.Domain.Enum;
using VirtualMuseum.Domain.Interfaces;
using VirtualMuseum.Domain.Interfaces.Services;
using VirtualMuseum.Domain.Resources;
using VirtualMuseum.Domain.Result;

namespace VirtualMuseum.Application.Services;

/// <inheritdoc />
public class AuthService : IAuthServices
{
    private readonly IBaseRepository<User> _userRepository;
    private readonly IBaseRepository<UserToken> _userTokenRepository;
    private readonly IBaseRepository<Role> _roleRepository;
    private readonly ITokenServices _tokenService;
    private readonly IMapper _mapper;

    public AuthService(
        IBaseRepository<User> userRepository, 
        IBaseRepository<UserToken> userTokenRepository, 
        ITokenServices tokenService, IMapper mapper, IBaseRepository<Role> roleRepository)
    {
        _userRepository = userRepository;
        _userTokenRepository = userTokenRepository;
        _tokenService = tokenService;
        _mapper = mapper;
        _roleRepository = roleRepository;
    }

    /// <inheritdoc />
    public async Task<BaseResult<UserDto>> Register(RegisterUserDto dto)
    {
        try
        {
            var user = await _userRepository.GetAll()
                .FirstOrDefaultAsync(x => x.Login == dto.Login);

            if (user != null)
            {
                return new BaseResult<UserDto>()
                {
                    ErrorMassage = ErrorMessage.UserAlreadyExists,
                    ErrorCode = (int)ErrorCode.UserAlreadyExists
                };
            }

            user = _mapper.Map<User>(dto);

            user.RoleId = 1;
            user.Password = HashPasswordHelper.HashPassword(dto.Password);

            await _userRepository.CreateAsync(user);

            return new BaseResult<UserDto>()
            {
                Data = _mapper.Map<UserDto>(user)
            };
        }
        catch (Exception e)
        {
            return new BaseResult<UserDto>()
            {
                ErrorMassage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }

    /// <inheritdoc />
    public async Task<BaseResult<TokenDto>> Login(LoginActorDto dto)
    {
        var user = await _userRepository.GetAll()
            .FirstOrDefaultAsync(x => x.Login == dto.Login);
        if (user == null)
        {
            return new BaseResult<TokenDto>()
            {
                ErrorMassage = ErrorMessage.UserNotFount,
                ErrorCode = (int)ErrorCode.UserNotFount
            };
        }
        
        if (!IsVerifyPassword(user.Password, dto.Password))
        {
            return new BaseResult<TokenDto>()
            {
                ErrorMassage = ErrorMessage.InvalidPassword,
                ErrorCode = (int)ErrorCode.InvalidPassword
            };
        }

        var role = await _roleRepository.GetAll()
            .FirstOrDefaultAsync(x => x.Id == user.RoleId);
        
        var claimes = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.Role, role.Name)
        };
        
        var accessToken = _tokenService.GenerateAccessToken(claimes);
        var refreshToken = _tokenService.GenerateRefreshToken();
        
        var userToken = await _userTokenRepository.GetAll()
            .FirstOrDefaultAsync(x => x.UserId == user.Id);

        if (userToken == null)
        {
            userToken = new UserToken()
            {
                UserId = user.Id,
                RefreshToken = refreshToken,
                RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7)
            };
            await _userTokenRepository.CreateAsync(userToken);
        }
        else
        {
            userToken.RefreshToken = refreshToken;
            userToken.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        }

        return new BaseResult<TokenDto>()
        {
            Data = new TokenDto(accessToken, refreshToken, user.Id)
        };
    }
    
    /// <summary>
    /// Верификация паролей.
    /// </summary>
    /// <param name="ActorPasswordHash">  </param>
    /// <param name="actorPasswors"></param>
    /// <returns> true, если пароли совпадают, false, если разные. </returns>
    private bool IsVerifyPassword(string ActorPasswordHash, string actorPasswors)
    {
        var hash = HashPasswordHelper.HashPassword(actorPasswors);
        return ActorPasswordHash == hash;
    }
}