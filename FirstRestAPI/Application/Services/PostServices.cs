using FirstRestAPI.Interfaces;
using FirstRestAPI.InterfacesRepositories;
using FirstRestAPI.Models.Base;
using FirstRestAPI.Repositories;
namespace FirstRestAPI.Services;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

public abstract class PostServices:IPostServices
{

    public readonly IPostRepository _postRepository;

    public PostServices(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }


    public override async Task<Post> GetPostAsync(int id)
    {
        return await _postRepository.GetPostAsync(id);
    }
    

    public override async Task<IEnumerable<Post>> GetPublishedPostsAsync()
    {
        return await _postRepository.GetPublishedPostsAsync();
    }

    public override async Task<IEnumerable<Post>> GetPostsForAuthorAsync(int authorId)
    {
        return await _postRepository.GetPostsForAuthorAsync(authorId);
    }

    public override async Task AddPostAsync(Post post)
    {
        await _postRepository.AddPostAsync(post);
    }


    public override async Task DeletePostAsync(int id)
    {
        await _postRepository.DeletePostAsync(id);
    }

    public override async Task UpdatePostAsync(Post post)
    {
        await _postRepository.UpdatePostAsync(post);
    }

    public override async Task PublishPostAsync(int id, int userId) {
        var post = await _postRepository.GetPostAsync(id);
        if (post == null) return;
        if (post.authorId != userId) return;
        post.ispublished = true;
        await _postRepository.UpdatePostAsync(post);
    }
}