using WebBaseBackend.Entities;
using WebBaseBackend.Services;
using static WebBaseBackend.Enums.Enum;

namespace WebBaseBackend.Commands
{
    public class CreatePostHandler
    {
        private readonly IPostRepository _postRepository;

        public CreatePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<int> Handle(CreatePostCommand command, Guid UserId, PostStatus status)
        {
            var post = new Post { Content = command.Content, UserId = UserId , Status= status };
            await _postRepository.AddPostAsync(post);
            return post.Id;
        }
    }
}
