using ForjaDev.Application.Dtos.StoreFront.Comments;

namespace ForjaDev.Application.Dtos.StoreFront.Posts;

public record PostByIdDTo
(
    string NameMember,
    string Title,
    string Body,
    string Tag,
    DateTime CreateAt,
    int Likes,
    IEnumerable<CommentDto>Comments)
{
    
}