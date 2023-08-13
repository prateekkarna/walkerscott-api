using System;
using walkerscott_domain.Entities;

namespace walkerscott_domain.Interfaces.Repository
{
	public interface INewsCategoryRepository
	{
        Task<List<NewsCategory>> GetCategories();
    }
}

