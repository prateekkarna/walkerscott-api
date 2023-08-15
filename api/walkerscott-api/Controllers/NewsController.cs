using Microsoft.AspNetCore.Mvc;
using walkerscott_api.Response;
using walkerscott_application.Command.Interfaces;
using walkerscott_application.Dto;
using walkerscott_application.Query.Interfaces;

namespace walkerscott_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsQuery _newsQuery;
        private readonly INewsCommand _newsCommand;
        public NewsController(INewsQuery newsQuery, INewsCommand newsCommand)
        {
            _newsQuery = newsQuery;
            _newsCommand = newsCommand;
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

        [HttpGet("Search")]
        public async Task<IActionResult> SearchNews(int pageNo, int perPage, string searchString = "")
        {
            try
            {
                var newsArticles = await _newsQuery.GetByCountAndSearchParam(pageNo, perPage, searchString);
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

        [HttpPost("CreateArticle")]
        public async Task<IActionResult> CreateArticle(CreateNewsArticleDto article)
        {
            try
            {
                var created = await _newsCommand.CreateNews(article);
                ApiResponse<bool> apiResponse = new ApiResponse<bool>()
                {
                    Data = created,
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

        [HttpPut("UpdateArticle")]
        public async Task<IActionResult> UpdateArticle(UpdateNewsDto article)
        {
            try
            {
                var created = await _newsCommand.UpdateNews(article);
                ApiResponse<bool> apiResponse = new ApiResponse<bool>()
                {
                    Data = created,
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

        [HttpDelete("DeleteArticle")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            try
            {
                var created = await _newsCommand.DeleteNews(id);
                ApiResponse<bool> apiResponse = new ApiResponse<bool>()
                {
                    Data = created,
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
