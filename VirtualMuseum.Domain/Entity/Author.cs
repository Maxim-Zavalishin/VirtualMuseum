using System.Security.AccessControl;
using VirtualMuseum.Domain.Interfaces;

namespace VirtualMuseum.Domain.Entity;

/// <summary>
/// Автор.
/// </summary>
public class Author : IBaseEntity<int>
{
    /// <inheritdoc />
    public int Id { get; set; }
    
    /// <summary>
    /// Имя.
    /// </summary>
    public string Firstname { get; set; }

    /// <summary>
    /// Отчество.
    /// </summary>
    public string? Secondname { get; set; }

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string Lastname { get; set; }

    /// <summary>
    /// Список статей автора.
    /// </summary>
    public List<AuthorArticle>? AuthorArticles { get; set; }

    /// <summary>
    ///  Список должностей автора.
    /// </summary>
    public List<AuthorPosition>? AuthorPositions { get; set; }
}