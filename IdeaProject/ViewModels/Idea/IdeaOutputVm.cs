namespace IdeaProject.ViewModels.Idea
{
    public class IdeaOutputVm
    {
        public string Title { get; set; }

        public string MainIdea { get; set; }

        public int UserId { get; set; }
        public List<IdeaOutputVm> Ideas { get; set; }
    }
}
