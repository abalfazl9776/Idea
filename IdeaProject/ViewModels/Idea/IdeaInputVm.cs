namespace IdeaProject.ViewModels.Idea;
using FluentValidation;

public class IdeaInputVm
{

    public string Title { get; set; }

    public string Idea { get; set; }
    public int UserId { get; set; }
}