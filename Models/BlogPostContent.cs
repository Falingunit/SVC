namespace SVC.Models
{
    public struct BlogPostContent
    {
        string Content { get; set; }

        public BlogPostContent(string content)
        {
            Content = content;
        }
    }
}
