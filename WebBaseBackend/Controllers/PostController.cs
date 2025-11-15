using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBaseBackend.Commands;
using WebBaseBackend.Services;

namespace WebBaseBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly CreatePostHandler _createPost;
        private readonly AddCommentHandler _addComment;
        private readonly AddLikeHandler _addLike;
        private readonly IPostRepository _posts;

        public PostController(CreatePostHandler createPost,
                               IPostRepository posts, AddCommentHandler addComment,
                               ICommentRepository comments)
        {
            _createPost = createPost;
            _posts = posts;
            _addComment = addComment;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostCommand command)
        {
            var id = await _createPost.Handle(command);
            return Ok(new { Id = id });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _posts.GetByPostIdAsync(id);
            return post == null ? NotFound() : Ok(post);
        }

        [HttpPost("{id}/comment")]
        public async Task<IActionResult> AddComment(int id, [FromBody] CreateCommentCommand command)
        {
            await _addComment.Handle(id, command);
            return Ok();
        }

        [HttpPost("{id}/like")]
        public async Task<IActionResult> AddLike(int id, [FromBody] string userId)
        {
            await _addLike.Handle(id, userId);
            return Ok();
        }
    }
}
