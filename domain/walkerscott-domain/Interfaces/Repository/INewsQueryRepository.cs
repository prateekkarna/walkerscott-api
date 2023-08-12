using walkerscott_domain.Entities;

namespace walkerscott_domain.Interfaces.Repository
{
    public interface INewsQueryRepository
    {
         Task<List<NewsArticle>> GetByTitle(string title);

         Task<List<NewsArticle>> GetAll();

        Task<int> GetTotalCount();

        Task<List<NewsArticle>> GetByPage(int pageNo, int perPageEntries, string searchParam);
    }
}
