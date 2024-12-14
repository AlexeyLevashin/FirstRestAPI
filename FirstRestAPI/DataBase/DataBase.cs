namespace FirstRestAPI.Models.Base;

public class ApplicationContext
{
       public List<Person> Users { get; } = new List<Person>();
       public List<Post> Posts { get; } = new List<Post>();
       public List<Image> Images { get; } = new List<Image>();
       
}

