namespace MessagingContracts;

public record CustomerUpdated(
    Guid Id,
    string Name,
    string Address,
    bool? IsActive,
    DateTime UpdatedAt
    );