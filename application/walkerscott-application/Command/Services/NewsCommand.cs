using walkerscott_application.Command.Interfaces;
using walkerscott_domain.Entities;

namespace walkerscott_application.Command.Services
{
    public class NewsCommand : INewsCommand
    {
        public Task<bool> CreateNews(NewsArticle newsArticle)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateNews(NewsArticle newsArticle)
        {
            throw new NotImplementedException();
        }
    }
}
