using System;
using Microsoft.EntityFrameworkCore;
using wakerscott_integration.DbConfigurations;
using walkerscott_domain.Entities;
using walkerscott_domain.Interfaces.Repository;

namespace wakerscott_integration.Services
{
	public class NewsCategoryRepository:INewsCategoryRepository
	{
        private ApplicationDbContext _dbContext;

        public NewsCategoryRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<NewsCategory>> GetCategories()
		{
			var listOfCategories = await _dbContext.NewsCategories.Select(x =>
			new NewsCategory
			{
				CategoryId = x.CategoryId,
				CategoryName = x.CategoryName
			}).ToListAsync();

			return listOfCategories;
		}

    }
}

