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
        private readonly IPostRepository _posts;

        public PostController(CreatePostHandler createPost,
                               IPostRepository posts)
        {
            _createPost = createPost;
            _posts = posts;
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
    }
}
