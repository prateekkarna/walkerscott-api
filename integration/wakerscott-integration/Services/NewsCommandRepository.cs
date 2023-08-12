using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using wakerscott_integration.DbConfigurations;
using walkerscott_domain.Entities;
using walkerscott_domain.Interfaces.Repository;
using System.Linq;

namespace wakerscott_integration.Services
{
    public class NewsCommandRepository : INewsCommandRepository
    {
        private ApplicationDbContext _dbContext;
        

        public NewsCommandRepository(ApplicationDbContext dbContext,IDbTransaction dbTransaction)
        {
            _dbContext = dbContext;
            _dbContext.Database.UseTransaction((DbTransaction)dbTransaction);
        }

        public async Task<bool> CreateNews(NewsArticle newsArticle)
        {
            try
            {
                await _dbContext.NewsArticles.AddAsync(newsArticle);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateNews(NewsArticle newsArticle)
        {
            try
            {
                var newsToUpdate = _dbContext.NewsArticles.First(x => x.ArticleId == newsArticle.ArticleId);
                newsToUpdate.Title = newsArticle.Title;
                newsToUpdate.Description = newsArticle.Description;
                newsToUpdate.CategoryId = newsArticle.CategoryId;
                _dbContext.NewsArticles.Update(newsToUpdate);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteNews(int id)
        {
            try
            {
                var articleToRemove = await _dbContext.NewsArticles.FirstOrDefaultAsync(n => n.ArticleId == id);
                if(articleToRemove != null) {
                    _dbContext.NewsArticles.Remove(articleToRemove);
                    return await _dbContext.SaveChangesAsync() > 0;
                }
                return false;
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
