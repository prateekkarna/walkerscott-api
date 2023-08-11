﻿using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using wakerscott_integration.DbConfigurations;
using walkerscott_domain.Entities;
using walkerscott_domain.Interfaces.Repository;

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

        public Task<bool> CreateNews(NewsArticle newsArticle)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateNews(NewsArticle newsArticle)
        {
            throw new NotImplementedException();
        }
    }
}
