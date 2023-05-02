namespace IdeaProject.ViewModels.Comment
{
    public class AddCommentVm
    {
        public string CommentBody { get; set; }
        public int UserId { get; set; }
        public int IdeaId { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
