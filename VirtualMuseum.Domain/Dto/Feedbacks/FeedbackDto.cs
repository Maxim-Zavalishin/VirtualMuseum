using VirtualMuseum.Domain.Dto.User;

namespace VirtualMuseum.Domain.Dto.Feedbacks;

public record FeedbackDto(
    string Text,
    DateTime CreatedAt,
    UserFeedbackDto User
);