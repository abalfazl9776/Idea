namespace DataAccess.Entities;

public class Idea
{
    public int Id { get; set; }
    public string Description { get; set; }
    
    public string Title { get; set; }

    public int UserId { get; set; }
    
    public DateTime DateTime { get; set; }
}