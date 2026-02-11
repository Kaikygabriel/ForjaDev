namespace ForjaDev.Domain.BackOffice.Abstract;

public abstract class Entity
{
    public Guid Id { get; init; } = Guid.NewGuid();
}