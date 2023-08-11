using Microsoft.AspNetCore.Mvc;
using walkerscott_api.Response;
using walkerscott_application.Dto;
using walkerscott_application.Query.Interfaces;

namespace walkerscott_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsQuery _newsQuery;
        public NewsController(INewsQuery newsQuery)
        {
            _newsQuery = newsQuery;
        }

        [HttpGet("GetNewsByPage")]
        public async Task<IActionResult> GetNewsByPage(int pageNo, int perPage)
        {
            try
            {
                var newsArticles = await _newsQuery.GetByPage(pageNo, perPage);
                ApiResponse<GetNewsResponseDto> apiResponse = new ApiResponse<GetNewsResponseDto>()
                { 
                    Data = newsArticles,
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
