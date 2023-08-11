using walkerscott_application.Command.Interfaces;
using walkerscott_domain.Entities;
using walkerscott_domain.Interfaces.Repository;
using walkerscott_domain.Interfaces.UnitOfWork;

namespace walkerscott_application.Command.Services
{
    public class NewsCommand : INewsCommand
    {
        private readonly INewsCommandRepository _newsCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NewsCommand(INewsCommandRepository newsCommandRepository, IUnitOfWork unitOfWork)
        {
            _newsCommandRepository = newsCommandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateNews(NewsArticle newsArticle)
        {
            try
            {
                var response = await _newsCommandRepository.CreateNews(newsArticle);

                if (response)
                {
                    _unitOfWork.Commit();
                }
                else
                {
                    _unitOfWork.Rollback();
                }

                return response;
            }
            catch(Exception ex)
            {
                _unitOfWork.Rollback();
                return false;
            }
        }

        public Task<bool> UpdateNews(NewsArticle newsArticle)
        {
            throw new NotImplementedException();
        }
    }
}
