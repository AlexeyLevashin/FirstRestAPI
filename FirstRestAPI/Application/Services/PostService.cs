using FirstRestAPI.Interfaces;
using FirstRestAPI.InterfacesRepositories;
using FirstRestAPI.Models.Base;
using FirstRestAPI.Repositories;

namespace FirstRestAPI.Services;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IPostService _postServiceImplementation;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }


    public async Task<Post> GetPostAsync(int id)
    {
        return await _postRepository.GetPost(id);
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return await _postRepository.GetAllPosts();
    }


    public async Task<IEnumerable<Post>> GetPublishedPostsAsync()
    {
        return await _postRepository.GetPublishedPosts();
    }

    public async Task<IEnumerable<Post>> GetPostsForAuthorAsync(int authorId)
    {
        return await _postRepository.GetPostsForAuthor(authorId);
    }

    public async Task AddPostAsync(Post post)
    {
        await _postRepository.AddPost(post);
    }


    public async Task DeletePostAsync(int id)
    {
        await _postRepository.DeletePost(id);
    }

    public async Task UpdatePostAsync(Post post)
    {
        await _postRepository.UpdatePost(post);
    }

    public async Task PublishPostAsync(int id, int userId)
    {
        var post = await _postRepository.GetPost(id);
        if (post == null) return;
        if (post.authorId != userId) return;
        post.ispublished = true;
        await _postRepository.UpdatePost(post);
    }
}