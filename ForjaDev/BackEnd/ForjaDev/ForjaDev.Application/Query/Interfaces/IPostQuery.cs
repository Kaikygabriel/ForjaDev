namespace ForjaDev.Application.Query.Interfaces;

public interface IPostQuery
{
    Task<IEnumerable<Domain.BackOffice.Entities.Post>> GetByTitle(string title);
}