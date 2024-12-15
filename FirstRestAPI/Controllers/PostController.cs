using Microsoft.AspNetCore.Mvc;
using FirstRestAPI;
using FirstRestAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using static FirstRestAPI.Common.Enums.ClaimType;
using static FirstRestAPI.Common.Enums.Roles;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
   [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostServices _postService;

        public PostsController(IPostServices postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetPostAsync(id);
            if (post == null) return NotFound();
            return Ok(post);
        }
        
        
        
        
        
        
        
        
        [Authorize(Roles = "Author")]
        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post)
        {
            // Add logic to get AuthorId from authenticated user
            post.authorId = GetUserId();//Example method - replace with actual logic
            await _postService.AddPostAsync(post);
            return CreatedAtAction(nameof(GetPost), new { id = post.postId }, post);
        }

        [Authorize(Roles = "Author")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, Post updatedPost)
        {
            var post = await _postService.GetPostAsync(id);
             if (post == null) return NotFound();

            if (post.authorId != GetUserId()) return Unauthorized();
              updatedPost.postId = post.postId;
            await _postService.UpdatePostAsync(updatedPost);
            return NoContent();
        }
        
        
        
        
        [Authorize(Roles = "Author")]
        [HttpPut("{id}/publish")]
        public async Task<IActionResult> PublishPost(int id)
        {
            await _postService.PublishPostAsync(id, GetUserId());
            return NoContent();
        }
         private int GetUserId() {
            //REPLACE THIS WITH YOUR ACTUAL USER ID RETRIEVAL LOGIC
            //This is a placeholder.  You'll need to get the user ID from the authentication system.
            return 1;
        }
    }
}
