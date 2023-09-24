namespace MessagingContracts;

public record CustomerCreated(
    Guid Id,
    string Name,
    string Address,
    bool? IsActive,
    DateTime CreatedAt
    );
