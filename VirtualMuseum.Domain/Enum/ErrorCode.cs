namespace VirtualMuseum.Domain.Enum;

public enum ErrorCode
{
    InternalServerError = 1,
    
    ArticleNotFount = 11,
    
    AuthorNotFount = 21,
    
    InvalidUserRequest = 111,
    UserAlreadyExists = 112, 
    UserNotFount = 113,
    InvalidPassword = 114, 
    
    InvalidToken = 121,
}