using walkerscott_domain.Entities;

namespace walkerscott_domain.Interfaces.Repository
{
    public interface INewsQueryRepository
    {
         Task<List<NewsArticle>> GetByTitle(string title);

        Task<List<NewsArticle>> GetByCountAndSearchParam(int count, string searchString);

        Task<int> GetTotalCount();

        Task<List<NewsArticle>> GetByPage(int pageNo, int perPageEntries);

        Task<List<NewsArticle>> GetByCount(int count, int skip);
    }
}
