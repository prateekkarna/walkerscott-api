using Azure;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using wakerscott_integration.DbConfigurations;
using walkerscott_domain.Entities;
using walkerscott_domain.Interfaces.Repository;

namespace wakerscott_integration.Services
{
    public class NewsQueryRepository : INewsQueryRepository
    {
        private ApplicationDbContext _dbContext;


        public NewsQueryRepository(ApplicationDbContext dbContext, IDbTransaction dbTransaction)
        {
            _dbContext = dbContext;
            _dbContext.Database.UseTransaction((DbTransaction)dbTransaction);
        }
        public async Task<List<NewsArticle>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<NewsArticle>> GetByPage(int pageNo, int perPageEntries, string searchParam)
        {
            try
            {
                var searchableWords = searchParam.Split(" ").ToList();
                var news = await _dbContext.NewsArticles
                .Include(a => a.Category)
                .OrderBy(x => x.CreatedOn)
                .Skip((pageNo - 1) * perPageEntries)
                .Take(perPageEntries)
                .Select(x =>
                new NewsArticle { 
                    ArticleId = x.ArticleId, 
                    Title = x.Title, 
                    Description = x.Description, 
                    CategoryId = x.CategoryId, 
                    CreatedOn = x.CreatedOn, 
                    Category = x.Category }
                ).ToListAsync();
                return news;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<int> GetTotalCount()
        {
            try
            {
                int news = await _dbContext.NewsArticles.AsQueryable().CountAsync();

                return news;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public async Task<List<NewsArticle>> GetByTitle(string title)
        {
            try
            {
                var news = await _dbContext.NewsArticles
                .Include(a => a.Category)
                .OrderBy(x => x.CreatedOn)
                .Select(x =>
                new NewsArticle
                {
                    Title = x.Title,
                    Description = x.Description,
                    CategoryId = x.CategoryId,
                    CreatedOn = x.CreatedOn,
                    Category = x.Category
                }
                ).ToListAsync();

                return news;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

    }
}
