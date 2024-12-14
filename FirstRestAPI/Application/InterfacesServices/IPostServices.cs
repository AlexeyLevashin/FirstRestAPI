namespace FirstRestAPI.Interfaces;

public abstract class IPostServices
{
    // public Task<Post> GetPostAsync(int id);
    // public Task<IEnumerable<Post>> GetPublishedPostsAsync();
    // public Task<IEnumerable<Post>> GetPostsForAuthorAsync(int authorId);
    // public Task AddPostAsync(Post post);
    // public Task UpdatePostAsync(Post post);
    // public Task DeletePostAsync(int id);
    // public Task PublishPostAsync(int id, int userId);
    public abstract Task<Post> GetPostAsync(int id);
    public abstract Task<IEnumerable<Post>> GetAllPostsAsync();
    public abstract Task<IEnumerable<Post>> GetPostsForAuthorAsync(int authorId);
    public abstract Task<IEnumerable<Post>> GetPublishedPostsAsync();
    public abstract Task AddPostAsync(Post post);
    public abstract Task UpdatePostAsync(Post post);
    public abstract Task DeletePostAsync(int id);
    public abstract Task PublishPostAsync(int id, int userId);
    // public Task<List<Post>> GetPostsForReader();
    // public Task<List<Post>> GetPostsForAuthor(int userId);
    // public Task<Post> AddPost(int authorId, AddNewPostRequestDto addNewPostRequestDto);
    // public Task UpdatePost(int userId, int postId, EditPostRequestDto editPostRequestDto);
    // public Task PublishPost(int userId, int postId, ChangePostStatusDto changePostStatusDto);
    // public Task<PostResponseDto> AddImageToPost(int postId, string objectName, Stream image);
    // public Task DeleteImageFromPost(int postId, int imageId, int userId);
}