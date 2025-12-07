namespace WebBaseBackend.Commands
{
    public record CreatePostCommand(string Content);
    public record UpdatePostCommand(string Content);
    public record CreateCommentCommand(string Text);
}
