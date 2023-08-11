using walkerscott_application.Dto;
using walkerscott_domain.Entities;

namespace walkerscott_application.Query.Interfaces
{
    public interface INewsQuery
    {
        public Task<GetNewsResponseDto> GetAllArticles();
        public Task<GetNewsResponseDto> GetByPage(int pageNo, int perPageEntries);
        public Task<GetNewsResponseDto> GetByTitle(string title);
    }
}
