using System;
using Microsoft.AspNetCore.Mvc;
using walkerscott_api.Response;
using walkerscott_application.Dto;
using walkerscott_application.Query.Interfaces;

namespace walkerscott_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
        private readonly INewsCategory _newsCategory;

		public CategoryController(INewsCategory newsCategory)
		{
            _newsCategory = newsCategory;
		}

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetNewsByPage()
        {
            try
            {
                var Categories = await _newsCategory.GetAllCategories();
                ApiResponse<GetCategoryResponseDto> apiResponse = new ApiResponse<GetCategoryResponseDto>()
                {
                    Data = Categories,
                    IsSuccess = true,
                    StatusCode = 200
                };

                return new OkObjectResult(apiResponse);

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

