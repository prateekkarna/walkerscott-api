using System;
using walkerscott_application.Dto;

namespace walkerscott_application.Query.Interfaces
{
	public interface INewsCategory
	{
        public Task<GetCategoryResponseDto> GetAllCategories();
    }
}

