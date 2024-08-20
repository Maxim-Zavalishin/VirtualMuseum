namespace VirtualMuseum.Domain.Enum;

public enum ErrorCode
{
    InternalServerError = 1,
    
    ArticleNotFound = 11,
    ArticleAlreadyExists = 12,
    
    AuthorNotFound = 21,
    
    PositionNotFound = 61,
    
    SubToticNotFound = 81,
    
    InvalidUserRequest = 111,
    UserAlreadyExists = 112, 
    UserNotFound = 113,
    InvalidPassword = 114, 
    
    InvalidToken = 121,
}