using walkerscott_application.Dto;
using walkerscott_domain.Entities;

namespace walkerscott_application.Command.Interfaces
{
    public interface INewsCommand
    {
        public Task<bool> CreateNews(CreateNewsArticleDto newsArticle);
        public Task<bool> UpdateNews(UpdateNewsDto newsArticle);
        public Task<bool> DeleteNews (int id);
    }
}
