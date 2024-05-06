using VirtualMuseum.Domain.Dto.Article;
using VirtualMuseum.Domain.Result;

namespace VirtualMuseum.Domain.Interfaces.Services;

public interface IArticleService
{
    /// <summary>
    /// Получение всех статей.
    /// </summary>
    /// <returns> Массив статей. </returns>
    Task<CollectionResult<ArticleDto>> GetArticlesAsync();
    
    /// <summary>
    /// Получение всех Id статей.
    /// </summary>
    /// <returns> Массив статей. </returns>
    Task<CollectionResult<GetArticleDto>> GetIdArticlesAsync();

    /// <summary>
    /// Получение конкретной статьи по id.
    /// </summary>
    /// <param name="id"> id конкретной статьи. </param>
    /// <returns> Конкретная статья. </returns>
    Task<BaseResult<ArticleDto>> GetIArticleByIdAsync(int id);

    /// <summary>
    /// Создание новой статьи.
    /// </summary>
    /// <param name="dto"> Создаваемая статья. </param>
    /// <returns> Создаваемая статья. </returns>
    Task<BaseResult<ArticleDto>> CreateArticleAsync(CreateArticleDto dto);

    /// <summary>
    /// Удаление статьи по id.
    /// </summary>
    /// <param name="id"> id удаляемой статьи. </param>
    /// <returns> Удаляемая статья. </returns>
    Task<BaseResult<ArticleDto>> DeleteArticleAsync(int id);

    /// <summary>
    /// Обновление данных конкретной статьи.
    /// </summary>
    /// <param name="dto"> Объект с обновленными данными. </param>
    /// <returns> Статья с обновленными данными. </returns>
    Task<BaseResult<ArticleDto>> UpdateArticleAsync(ArticleDto dto);
}