namespace walkerscott_application.Dto
{
    public class NewsArticleDto
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public DateTime? CreatedOn { get; set; }

    }
}
