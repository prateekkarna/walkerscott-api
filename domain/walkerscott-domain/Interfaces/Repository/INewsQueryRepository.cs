using walkerscott_domain.Entities;

namespace walkerscott_domain.Interfaces.Repository
{
    public interface INewsQueryRepository
    {
         Task<NewsArticle> GetByTitle(string title);

         Task<List<NewsArticle>> GetAll();

        Task<List<NewsArticle>> GetByPage(int pageNo, int perPageEntries);
    }
}
