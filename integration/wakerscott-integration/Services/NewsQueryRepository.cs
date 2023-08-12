using Azure;
using Microsoft.EntityFrameworkCore;
using wakerscott_integration.DbConfigurations;
using walkerscott_domain.Entities;
using walkerscott_domain.Interfaces.Repository;

namespace wakerscott_integration.Services
{
    public class NewsQueryRepository : INewsQueryRepository
    {
        private ApplicationDbContext _dbContext;


        public NewsQueryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<NewsArticle>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<NewsArticle>> GetByPage(int pageNo, int perPageEntries)
        {
            var news = await _dbContext.NewsArticles
                .Include(a => a.Category)
                .OrderBy(x => x.CreatedOn)
                .Skip((pageNo - 1) * perPageEntries)
                .Take(perPageEntries)
                .Select(x =>
                new NewsArticle { ArticleId = x.ArticleId,Title = x.Title, Description = x.Description, CategoryId = x.CategoryId,CreatedOn = x.CreatedOn,Category = x.Category }
                ).ToListAsync();            
            return news;
        }

        public async Task<NewsArticle> GetByTitle(string title)
        {
            //var news = await _dbContext.NewsArticles
            //    .Include(a => a.Category)
            //    .OrderBy(x => x.CreatedOn)
            //    .Select(x =>
            //    new NewsArticle { Title = , Description = x.Description, CategoryId = x.CategoryId,
            //        CreatedOn = x.CreatedOn, Category = x.Category }
            //    ).ToListAsync();

            //return news;
            throw new NotImplementedException();
        }

    }
}
