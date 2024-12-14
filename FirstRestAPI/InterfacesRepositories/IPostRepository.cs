using FirstRestAPI.Models;

namespace FirstRestAPI.InterfacesRepositories;

public interface IPostRepository
{
    public Task<Post> GetPostAsync(int id);
    public Task<IEnumerable<Post>> GetAllPostsAsync();
    public Task<IEnumerable<Post>> GetPostsForAuthorAsync(int authorId);
    public Task<IEnumerable<Post>> GetPublishedPostsAsync();
    public Task AddPostAsync(Post post);
    public Task UpdatePostAsync(Post post);
    public Task DeletePostAsync(int id);
    
    
    
    // public Task<List<Post>> GetAllPostsByUserId(int userId);
    // public Task<Post?> GetPostById(int id);
    // public Task<Post> AddPost(Post post);
    // public Task UpdatePost(Post post);
    // public Task DeleteImage(int imageId);
    // public Task PublishPost(int id);
    // public Task<Image> AddImageToPost(int postId, string imageName);
    // public Task<Post?> GetPostByIdempotencyKey(string idempotencyKey);

}
