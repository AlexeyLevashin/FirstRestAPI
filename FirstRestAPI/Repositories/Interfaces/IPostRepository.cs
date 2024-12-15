using FirstRestAPI.Models;

namespace FirstRestAPI.InterfacesRepositories;

public interface IPostRepository
{
    public Task<Post> GetPost(int id);
    public Task<IEnumerable<Post>> GetAllPosts();
    public Task<IEnumerable<Post>> GetPostsForAuthor(int authorId);
    public Task<IEnumerable<Post>> GetPublishedPosts();
    public Task AddPost(Post post);
    public Task UpdatePost(Post post);
    public Task DeletePost(int id);
}