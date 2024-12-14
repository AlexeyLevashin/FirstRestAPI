using System.ComponentModel.DataAnnotations;

namespace FirstRestAPI;

public class Post
{
    public int	postId { get; set; }
    [Required]
    public int	authorId { get; set; }
    [Required]
    public string	idempotencyKey { get; set; }
    public string	title { get; set; }
    public string	content { get; set; }
    public DateTime	createdAt { get; set; }
    public DateTime	updatedAt { get; set; }
    public bool	ispublished { get; set; }
    public List<Image> images { get; set; }
    
}