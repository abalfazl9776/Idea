namespace DataContract.Models;

public class AddIdeaDto
{
    public string Idea { get; set; }
    
    public string Title { get; set; }

    public int UserId { get; set; }
    
    public DateTime DateTime { get; set; }
}