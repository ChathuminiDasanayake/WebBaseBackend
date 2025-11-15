using WebBaseBackend.Entities;
using WebBaseBackend.Services;

namespace WebBaseBackend.Commands
{
    public class AddLikeHandler
    {
        private readonly ILikeRepository _likeRepository;

        public AddLikeHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task Handle(int postId, string userId)
        {
            var like = new Like { PostId = postId, UserId = userId };
            await _likeRepository.AddLikeAsync(like);
        }
    }
}
