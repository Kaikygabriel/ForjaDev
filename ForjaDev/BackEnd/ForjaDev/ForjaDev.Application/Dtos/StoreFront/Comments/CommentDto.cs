namespace ForjaDev.Application.Dtos.StoreFront.Comments;

public record CommentDto
(
    string Message,
    DateTime CreateAt,
    string MemberName
)
{
    public static IEnumerable<CommentDto> ToCommentDtos(IEnumerable<Domain.BackOffice.Entities.Comment> comments)
        => comments.Select(x => (CommentDto)x);
    public static explicit operator CommentDto(Domain.BackOffice.Entities.Comment comment)
        => new(comment.Message, comment.CreateAt, comment.Member is null ? string.Empty : comment.Member.Name );
}