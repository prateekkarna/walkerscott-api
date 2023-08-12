using walkerscott_domain.Entities;

namespace walkerscott_domain.Interfaces.Repository
{
    public interface INewsCommandRepository
    {
        Task<bool> CreateNews(NewsArticle newsArticle);

        Task<bool> UpdateNews(NewsArticle newsArticle);

        Task<bool> DeleteNews(int id);
    }
}
