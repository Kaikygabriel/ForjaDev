using System.Security.AccessControl;

namespace ForjaDev.Application.Dtos.StoreFront.Posts;

public record PostDto
(
    Guid Id,
    string Title,
    string Body,
    string Tag,
    DateTime CreateAt,
    int Likes,
    Domain.BackOffice.Entities.Category? Category
)
{
    public static IEnumerable<PostDto> ToPostDtos(IEnumerable<Domain.BackOffice.Entities.Post> posts)
        => posts.Select(x => (PostDto)x);
    public static explicit operator PostDto(Domain.BackOffice.Entities.Post post)
        => new(post.Id,post.Title, post.Body, post.Tag, post.CreateAt, post.Likes.Count, post.Category);
}