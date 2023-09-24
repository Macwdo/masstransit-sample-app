namespace MessagingContracts;

public record CustomerActivated(
    Guid Id,
    string Name,
    string Address,
    bool? IsActive,
    DateTime CreatedAt
);