namespace walkerscott_domain.Entities
{
    public class NewsCategory
    {
        public NewsCategory()
        {
            NewsArticles = new HashSet<NewsArticle>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public virtual ICollection<NewsArticle> NewsArticles { get; set; }
    }
}
