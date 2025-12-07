using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBaseBackend.Commands;
using WebBaseBackend.Entities;
using WebBaseBackend.Services;
using static WebBaseBackend.Enums.Enum;

namespace WebBaseBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly CreatePostHandler _createPost;
        private readonly UpdatePostHandler _updatePost;
        private readonly AddCommentHandler _addComment;
        private readonly AddLikeHandler _addLike;
        private readonly IPostRepository _posts;

        public PostController(CreatePostHandler createPost, UpdatePostHandler updatePost,
        IPostRepository posts, AddCommentHandler addComment,
                               ICommentRepository comments)
        {
            _createPost = createPost;
            _updatePost = updatePost;
            _posts = posts;
            _addComment = addComment;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreatePostCommand command)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var status = PostStatus.Active;
            var id = await _createPost.Handle(command,userId, status);
            return Ok(new { Id = id });
        }

        [HttpPut("{postId}")]
        [Authorize]
        public async Task<IActionResult> Update(int postId, [FromBody] UpdatePostCommand command)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var result=await _updatePost.Handle(command, userId, postId);
            return Ok(result);
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
