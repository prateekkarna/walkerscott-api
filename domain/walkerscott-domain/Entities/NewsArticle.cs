namespace walkerscott_domain.Entities
{
    public class NewsArticle
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public virtual NewsCategory Category { get; set; }
    }
}
