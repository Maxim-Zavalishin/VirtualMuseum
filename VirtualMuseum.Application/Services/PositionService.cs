using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualMuseum.Application.Resources;
using VirtualMuseum.Domain.Dto.Position;
using VirtualMuseum.Domain.Entity;
using VirtualMuseum.Domain.Enum;
using VirtualMuseum.Domain.Interfaces;
using VirtualMuseum.Domain.Interfaces.Services;
using VirtualMuseum.Domain.Result;

namespace VirtualMuseum.Application.Services;

public class PositionService : IPositionService
{
    private readonly IBaseRepository<Position> _positionRepository;
    private readonly IMapper _mapper;

    public PositionService(IBaseRepository<Position> positionRepository, IMapper mapper)
    {
        _positionRepository = positionRepository;
        _mapper = mapper;
    }
    public CollectionResult<PositionDto> GetPositionsAsync()
    {
        try
        {
            var position = _positionRepository.GetAll().Select(x => _mapper.Map<PositionDto>(x));

            if (position == null)
            {
                return new CollectionResult<PositionDto>()
                {
                    ErrorMassage = ErrorMessage.PositionNotFound,
                    ErrorCode = (int)ErrorCode.PositionNotFound
                };
            }

            return new CollectionResult<PositionDto>()
            {
                Data = position
            };
        }
        catch (Exception e)
        {
            return new CollectionResult<PositionDto>()
            {
                ErrorCode = (int)ErrorCode.InternalServerError,
                ErrorMassage = ErrorMessage.InternalServerError
            };
        }
    }

    public async Task<BaseResult> CreatePositionAsync(PositionDto dto)
    {
        try
        {
            var position = await _positionRepository.GetAll().FirstOrDefaultAsync(x => x.Name == dto.Name);

            if (position != null)
            {
                return new BaseResult();
            }

            position = _mapper.Map<Position>(dto);

            await _positionRepository.CreateAsync(position);
            await _positionRepository.SaveChangesAsync();

            return new BaseResult();
        }
        catch (Exception e)
        {
            return new BaseResult()
            {
                ErrorCode = (int)ErrorCode.InternalServerError,
                ErrorMassage = ErrorMessage.InternalServerError
            };
        }
    }

    public async Task<BaseResult> DeletePositionAsync(int id)
    {
        try
        {
            var position = await _positionRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);

            if (position == null)
            {
                return new BaseResult();
            }

            _positionRepository.Remove(position);
            await _positionRepository.SaveChangesAsync();

            return new BaseResult();

        }
        catch (Exception e)
        {
            return new BaseResult()
            {
                ErrorCode = (int)ErrorCode.InternalServerError,
                ErrorMassage = ErrorMessage.InternalServerError
            };
        }
    }

    public async Task<BaseResult> UpdatePositionAsync(PositionDto dto)
    {
        try
        {
            var position = _positionRepository.GetAll().FirstOrDefaultAsync(x => x.Name == dto.Name);

            if (position == null)
            {
                return new BaseResult();
            }

            _positionRepository.Remove(_mapper.Map<Position>(dto));
            await _positionRepository.SaveChangesAsync();

            return new BaseResult();
        }
        catch (Exception e)
        {
            return new BaseResult()
            {
                ErrorCode = (int)ErrorCode.InternalServerError,
                ErrorMassage = ErrorMessage.InternalServerError
            };
        }
    }
}