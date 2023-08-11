using walkerscott_domain.Entities;

namespace walkerscott_application.Command.Interfaces
{
    public interface INewsCommand
    {
        public Task<bool> CreateNews(NewsArticle newsArticle);
        public Task<bool> UpdateNews(NewsArticle newsArticle);
    }
}
