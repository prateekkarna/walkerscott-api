using walkerscott_application.Dto;
using walkerscott_application.Query.Interfaces;
using walkerscott_domain.Entities;
using walkerscott_domain.Interfaces.Repository;

namespace walkerscott_application.Query.Services
{
    public class NewsQuery : INewsQuery
    {
        private readonly INewsQueryRepository newsQueryRepository;
        public NewsQuery(INewsQueryRepository _newsQueryRepository)
        {
            newsQueryRepository = _newsQueryRepository;
        }
        public async Task<GetNewsResponseDto> GetAllArticles()
        {
            throw new NotImplementedException();
        }

        public async Task<GetNewsResponseDto> GetByPage(int pageNo, int perPageEntries)
        {
          var newsArticles =  await newsQueryRepository.GetByPage(pageNo, perPageEntries);
            GetNewsResponseDto getNewsResponseDto = new GetNewsResponseDto()
            { 
                Articles = new List<NewsArticleDto>(), 
               // PrevPageLink = 
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
