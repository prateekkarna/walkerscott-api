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

        public async Task<GetNewsResponseDto> GetByCountAndSearchParam(int pageNo, int perPage, string searchString, int record)
        {

            if (!String.IsNullOrEmpty(searchString))
            {
                var totalCount = await _newsQueryRepository.GetTotalCount();

                var bestMatch = new List<NewsArticle>();

                int loop = 0;

                while (bestMatch.Count < perPage)
                {
                    var articles = await GetByCount(perPage * 5 , pageNo * loop * perPage * 5);
                    var match = MatchUtil.FindTopNBestMatch(searchString, articles, perPage).ToList();
                    match.ForEach(m => bestMatch.Add(m));
                    loop++;
                    if (pageNo * loop * perPage * 5> totalCount)
                        break;

                }


                GetNewsResponseDto getNewsResponseDto = new GetNewsResponseDto()
                {
                    Articles = new List<NewsArticleDto>(),
                    //PrevPageLink = prevPageLink,
                    //NextPageLink = nextPageLink,
                    //NoOfPages = totalPages
                };

                foreach (var article in bestMatch)
                {
                    var newArticle = new NewsArticleDto()
                    {
                        ArticleId = article.ArticleId,
                        Description = article.Description,
                        Title = article.Title,
                        CategoryName = article.Category.CategoryName,
                        CategoryId = article.Category.CategoryId,
                        CreatedOn = article.CreatedOn
                    };

                    getNewsResponseDto.Articles.Add(newArticle);

                }
                return getNewsResponseDto;
            }
            else
            {
                return await GetByPage(pageNo, perPage);
            }
        }

        private async Task<List<NewsArticle>> GetByCount(int count, int skip)
        {
            return await _newsQueryRepository.GetByCount(count, skip);
        }

        public async Task<GetNewsResponseDto> GetByPage(int pageNo, int perPageEntries)
        {
            var newsArticles =  await _newsQueryRepository.GetByPage(pageNo, perPageEntries);
            var totalEntries = await _newsQueryRepository.GetTotalCount();
            var totalPages = (totalEntries / perPageEntries) + (totalEntries % perPageEntries == 0 ? 0 : 1) ;

            var prevPage = pageNo == 1 ? pageNo : pageNo - 1;
            var nextPage = pageNo != totalPages ? pageNo + 1 : 0;

            var prevPageLink =
                pageNo == 1 ? null : "https://" + _requestInfo.Host + $"/api/News/GetNewsByPage?pageNo={prevPage}" + "&" + $"perPage={perPageEntries}";
            var nextPageLink =
                pageNo == totalPages ? null : "https://" + _requestInfo.Host + $"/api/News/GetNewsByPage?pageNo={nextPage}" + "&" + $"perPage={perPageEntries}";
            

            GetNewsResponseDto getNewsResponseDto = new GetNewsResponseDto()
            {
                Articles = new List<NewsArticleDto>(),
                PrevPageLink = prevPageLink,
                NextPageLink = nextPageLink,
                NoOfPages = totalPages
            };

             foreach(var article in newsArticles) {
                var newArticle = new NewsArticleDto()
                {
                    ArticleId = article.ArticleId,
                    Description = article.Description,
                    Title = article.Title,  
                    CategoryName = article.Category.CategoryName,    
                    CategoryId = article.Category.CategoryId,
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
