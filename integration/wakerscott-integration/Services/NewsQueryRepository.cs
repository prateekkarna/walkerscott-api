using Azure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
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
        public async Task<List<NewsArticle>> GetByCountAndSearchParam(int count, string searchString)
        {
            try
            {
                var strCompareHash = searchString.Split(' ');
                var news = await _dbContext.NewsArticles.Include(a => a.Category)
                    .OrderBy(a => a.CreatedOn)
                    .Where(n => strCompareHash.Any(x => n.Description.Contains(x)))
                    .Take(count)
                    .Select(x =>
                        new NewsArticle
                            {
                                ArticleId = x.ArticleId,
                                Title = x.Title,
                                Description = x.Description,
                                CategoryId = x.CategoryId,
                                CreatedOn = x.CreatedOn,
                                Category = x.Category
                            })
                    .ToListAsync();

                return news;


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool CheckIfMatches(HashSet<string> x, string y ) => x.Intersect(y.Split(' ', StringSplitOptions.None).ToHashSet()).Count() > 0;

        //Expression<Func<int>> testExpr = () => CheckIfMatches(3, 4);

        public async Task<List<NewsArticle>> GetByPage(int pageNo, int perPageEntries)
        {
            try
            {
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
                int newsCount = await _dbContext.NewsArticles.AsQueryable().CountAsync();

                return newsCount;
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

        public async Task<List<NewsArticle>> GetByCount(int count, int skip)
        {
            try
            {
                var news = await _dbContext.NewsArticles.Include(a => a.Category)
                    .OrderBy(a => a.CreatedOn)
                    .Skip(skip)
                    .Take(count)
                    .Select(x =>
                        new NewsArticle
                        {
                            ArticleId = x.ArticleId,
                            Title = x.Title,
                            Description = x.Description,
                            CategoryId = x.CategoryId,
                            CreatedOn = x.CreatedOn,
                            Category = x.Category
                        })
                    .ToListAsync();

                return news;


            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
