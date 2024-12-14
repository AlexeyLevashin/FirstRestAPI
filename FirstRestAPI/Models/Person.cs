namespace FirstRestAPI;

public class Person
{
    public int userId { get; set; }
    public Guid email { get; set; }
    public string passwordHash { get; set; }
    public string role { get; set; }
    public string refreshToken { get; set; }
    
}