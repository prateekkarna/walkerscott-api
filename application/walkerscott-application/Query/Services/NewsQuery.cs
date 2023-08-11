using walkerscott_application.Dto;
using walkerscott_application.Query.Interfaces;
using walkerscott_application.Utilities;
using walkerscott_domain.Entities;
using walkerscott_domain.Interfaces.Repository;

namespace walkerscott_application.Query.Services
{
    public class NewsQuery : INewsQuery
    {
        private readonly INewsQueryRepository _newsQueryRepository;
        private readonly RequestInfo _requestInfo;

        public NewsQuery(INewsQueryRepository newsQueryRepository, RequestInfo requestInfo)
        {
            _newsQueryRepository = newsQueryRepository;
            _requestInfo = requestInfo;
        }
        public async Task<GetNewsResponseDto> GetAllArticles()
        {
            throw new NotImplementedException();
        }

        public async Task<GetNewsResponseDto> GetByPage(int pageNo, int perPageEntries)
        {
          var newsArticles =  await _newsQueryRepository.GetByPage(pageNo, perPageEntries);
            var prevPage = pageNo == 1 ? pageNo : pageNo-1;
            GetNewsResponseDto getNewsResponseDto = new GetNewsResponseDto()
            {
                Articles = new List<NewsArticleDto>(),
                PrevPageLink = "https://" + _requestInfo.Host + $"/api/News/GetNewsByPage?pageNo={prevPage}" + "&" + $"perPage={perPageEntries}",
                //NextPageLink = "https://" + _requestInfo.Host + $"/api/News/GetNewsByPage?pageNo={pageNo+1}" + "&" + $"perPage={perPageEntries}"
                NextPageLink = "https://" + _requestInfo.Host + _requestInfo.Path + _requestInfo.QueryString
            };
             foreach(var article in newsArticles) {
                var newArticle = new NewsArticleDto()
                {
                    Description = article.Description,
                    Title = article.Title,  
                    CategoryName = article.Category.CategoryName,    
                    CreatedOn   = article.CreatedOn
                };

                getNewsResponseDto.Articles.Add(newArticle);
                
            }
            return getNewsResponseDto;
        }

        public async Task<GetNewsResponseDto> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
