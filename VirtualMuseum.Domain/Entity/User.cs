using System.Security.AccessControl;
using VirtualMuseum.Domain.Interfaces;

namespace VirtualMuseum.Domain.Entity;

/// <summary>
/// Пользователь.
/// </summary>
public class User : IBaseEntity<int>
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
    public string Secondname { get; set; }

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string Lastname { get; set; }

    /// <summary>
    /// Электроннаяя почта.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Логин.
    /// </summary>
    public string Login { get; set; }

    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Рассылка.
    /// </summary>
    public bool Mailing { get; set; }

    /// <summary>
    /// Роль пользователя.
    /// </summary>
    public Role? Role { get; set; }
    
    /// <summary>
    /// Id роли пользователя.
    /// </summary>
    public int? RoleId { get; set; }

    /// <summary>
    /// Список отзывов пользователя.
    /// </summary>
    public List<Feedback>? Feedbacks { get; set; }
}