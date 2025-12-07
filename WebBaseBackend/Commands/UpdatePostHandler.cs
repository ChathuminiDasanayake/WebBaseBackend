using static WebBaseBackend.Enums.Enum;
using WebBaseBackend.Entities;
using WebBaseBackend.Services;

namespace WebBaseBackend.Commands
{
    public class UpdatePostHandler
    {
        private readonly IPostRepository _postRepository;

        public UpdatePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }


        public async Task<string> Handle(UpdatePostCommand command, Guid UserId, int postId)
        {
            var post = await _postRepository.GetByPostIdAsync(postId);

            if (post == null)
                return ("No post Found");
            if (post.UserId == UserId)
            {
                // Update fields
                post.Content = command.Content;

                // Save changes
                await _postRepository.UpdatePostAsync(post);
                return ("Updated Successfully");
            }
            else
            {
                return ("You have not permission to edit this Post");
            }

        }
    }
}
