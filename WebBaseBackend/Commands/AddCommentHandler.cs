using WebBaseBackend.Entities;
using WebBaseBackend.Services;

namespace WebBaseBackend.Commands
{
    public class AddCommentHandler
    {
        private readonly ICommentRepository _commentRepository;

        public AddCommentHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<int> Handle(int postId, CreateCommentCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            if (string.IsNullOrWhiteSpace(command.Text))
                throw new ArgumentException("Comment text cannot be empty");

            var comment = new Comment { PostId = postId, Text = command.Text };
            await _commentRepository.AddCommentAsync(comment);
            return comment.Id;
        }

       
    }
}
