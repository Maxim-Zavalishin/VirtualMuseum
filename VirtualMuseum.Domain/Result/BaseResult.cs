using VirtualMuseum.Domain.Dto.User;

namespace VirtualMuseum.Domain.Result;

public class BaseResult
{
    public bool IsSuccess => String.IsNullOrEmpty(ErrorMassage);
    
    /// <summary>
    /// 
    /// </summary>
    public string ErrorMassage { get; set; }
    
    public int ErrorCode { get; set; }
}

public class BaseResult<T> : BaseResult
{
    
    public T Data { get; set; }
}

public class CollectionResult<T> : BaseResult<IEnumerable<T>>
{
}

