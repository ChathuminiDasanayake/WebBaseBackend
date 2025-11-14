using WebBaseBackend.Entities;
using WebBaseBackend.Services;

namespace WebBaseBackend.Commands
{
    public class CreatePostHandler
    {
        private readonly IPostRepository _postRepository;

        public CreatePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<int> Handle(CreatePostCommand command)
        {
            var post = new Post { Content = command.Content };
            await _postRepository.AddPostAsync(post);
            return post.Id;
        }
    }
}
