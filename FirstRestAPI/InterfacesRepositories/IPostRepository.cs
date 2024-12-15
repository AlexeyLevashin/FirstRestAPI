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
    
}
