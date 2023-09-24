namespace MessagingContracts;

public record CustomerDeleted(
    Guid Id,
    string Name,
    string Address,
    bool? IsActive,
    DateTime UpdatedAt
);