using walkerscott_application.Command.Interfaces;
using walkerscott_application.Dto;
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

        public async Task<bool> CreateNews(CreateNewsArticleDto newsArticle)
        {
            NewsArticle article = new NewsArticle
            {
                Title = newsArticle.Title,
                Description = newsArticle.Description,
                CategoryId = newsArticle.CategoryId,
                CreatedBy = "Admin"
            };
            try
            {
                var response = await _newsCommandRepository.CreateNews(article);

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

       public async Task<bool> DeleteNews(int id)
        {
            try
            {
                var response = await _newsCommandRepository.DeleteNews(id);

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
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                return false;
            }
        }

        public async Task<bool> UpdateNews(UpdateNewsDto newsArticle)
        {
            NewsArticle article = new NewsArticle
            {
                ArticleId = newsArticle.ArticleId,
                Title = newsArticle.Title,
                Description = newsArticle.Description,
                CategoryId = newsArticle.CategoryId,
                ModifiedBy = "Admin",
                ModifiedOn = DateTime.Now,
            };
            try
            {
                var response = await _newsCommandRepository.UpdateNews(article);

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
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                return false;
            }
        }
    }
}
