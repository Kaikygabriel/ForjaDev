namespace ForjaDev.Domain.BackOffice.Commum;

public record Error(string Title, string Message)
{
    public static Error MemberNotFound() => new("Member.NotFound", "Not Found!");

    public static Error PostNotFound() => new ("post.NotFound", "not found !");
};