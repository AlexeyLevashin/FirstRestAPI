using FirstRestAPI.InterfacesRepositories;
using FirstRestAPI.Models.Base;

namespace FirstRestAPI.Repositories;

public class PostRepository:ApplicationContext, IPostRepository
{

    private readonly ApplicationContext _context;

    public PostRepository(ApplicationContext context)
    {
        _context = context;
    }


    public async Task<Post> GetPostAsync(int id) {
        return await Task.FromResult(_context.Posts.FirstOrDefault(p => p.postId == id));
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return await Task.FromResult(_context.Posts);
    }


    public async Task<IEnumerable<Post>> GetPostsForAuthorAsync(int authorId)
    {
        return await Task.FromResult(_context.Posts.Where(p => p.authorId == authorId));
    }
    public async Task<IEnumerable<Post>> GetPublishedPostsAsync() {
        return await Task.FromResult(_context.Posts.Where(p => p.ispublished));
    }

    public async Task AddPostAsync(Post post)
    {
        _context.Posts.Add(post);
        await Task.CompletedTask;
    }

    public async Task UpdatePostAsync(Post post)
    {
        var existingPost = _context.Posts.FirstOrDefault(p => p.postId == post.postId);
        if (existingPost != null) {
            var index = _context.Posts.IndexOf(existingPost);
            _context.Posts[index] = post;
        }
        await Task.CompletedTask;
    }

    public async Task DeletePostAsync(int id)
    {
        var postToRemove = _context.Posts.FirstOrDefault(p => p.postId == id);
        if (postToRemove != null) {
            _context.Posts.Remove(postToRemove);
        }
        await Task.CompletedTask;
    }
}
