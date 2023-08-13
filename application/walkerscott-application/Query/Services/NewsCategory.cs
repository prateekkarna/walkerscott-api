using System;
using walkerscott_application.Dto;
using walkerscott_application.Query.Interfaces;
using walkerscott_domain.Interfaces.Repository;

namespace walkerscott_application.Query.Services
{
	public class NewsCategory : INewsCategory
	{
		private readonly INewsCategoryRepository _newsCategoryRepository;

		public NewsCategory(INewsCategoryRepository newsCategoryRepository)
		{
			_newsCategoryRepository = newsCategoryRepository;
		}

		public async Task<GetCategoryResponseDto> GetAllCategories()
		{
			var categories = await _newsCategoryRepository.GetCategories();
			GetCategoryResponseDto getCategoryResponseDto = new GetCategoryResponseDto()
			{
				Categories = new List<Category>()
			};
			foreach(var category in categories)
			{
				var newscategory = new Category()
				{
					CategoryId = category.CategoryId,
					CategoryName = category.CategoryName
				};
				getCategoryResponseDto.Categories.Add(newscategory);
			}
            return getCategoryResponseDto;
        }
    }
}

