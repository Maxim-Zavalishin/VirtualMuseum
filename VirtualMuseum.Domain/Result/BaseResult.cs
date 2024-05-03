using VirtualMuseum.Domain.Dto.User;

namespace VirtualMuseum.Domain.Result;

public class BaseResult<T> 
{
    /// <summary>
    /// 
    /// </summary>
    public bool IsSuccess => String.IsNullOrEmpty(ErrorMassage);
    
    /// <summary>
    /// 
    /// </summary>
    public string ErrorMassage { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int ErrorCode { get; set; }

    public T Data { get; set; }
}
