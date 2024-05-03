namespace VirtualMuseum.Domain.Enum;

public enum ErrorCode
{
    InternalServerError = 1,
    
    
    
    InvalidUserRequest = 101,
    UserAlreadyExists = 102, 
    UserNotFount = 103,
    InvalidPassword = 104, 
    
    InvalidToken = 111,
}