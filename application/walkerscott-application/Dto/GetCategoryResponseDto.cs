using System;
namespace walkerscott_application.Dto
{
	public class GetCategoryResponseDto
	{
		
			public List<Category>? Categories { get; set; }
		
	}

	public class Category
	{
		public int? CategoryId { get; set; }
		public string? CategoryName { get; set; }
	}
}

