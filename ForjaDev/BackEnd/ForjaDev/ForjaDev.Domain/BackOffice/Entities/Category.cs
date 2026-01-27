using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Entities.Abstraction;

namespace ForjaDev.Domain.BackOffice.Entities;

public class Category : Entity
{
    private Category()
    {
        
    }
    private Category(string title)
    {
        Title = title;
    }

    public string Title { get; private set; }
    public List<Post>Posts { get; private set; } = new();

    public static class Factory
    {
        public static Result<Category> Create(string title)
        {
            return Result<Category>.Success(new(title));
        }
    }
}