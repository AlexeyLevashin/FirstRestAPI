namespace FirstRestAPI.Interfaces;

public interface IPostServices
{
    public Task<Post> GetPostAsync(int id);
    public Task<IEnumerable<Post>> GetAllPostsAsync();
    // public Task<IEnumerable<Post>> GetPostsForAuthorAsync(int authorId);
    // public Task<IEnumerable<Post>> GetPublishedPostsAsync();
    public Task AddPostAsync(Post post);
    public Task UpdatePostAsync(Post post);
    // public Task DeletePostAsync(int id);
    public Task PublishPostAsync(int id, int userId);

}