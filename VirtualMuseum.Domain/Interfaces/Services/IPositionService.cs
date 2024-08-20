using VirtualMuseum.Domain.Dto.Position;
using VirtualMuseum.Domain.Result;

namespace VirtualMuseum.Domain.Interfaces.Services;

public interface IPositionService
{
    /// <summary>
    /// Получение списка всех позиций.
    /// </summary>
    /// <returns></returns>
    CollectionResult<PositionDto> GetPositionsAsync();

    /// <summary>
    /// Создание повой позиции.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<BaseResult> CreatePositionAsync(PositionDto dto);

    /// <summary>
    /// Удаление позиции.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<BaseResult> DeletePositionAsync(int id);

    /// <summary>
    /// Обновление позиции.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<BaseResult> UpdatePositionAsync(PositionDto dto);
}