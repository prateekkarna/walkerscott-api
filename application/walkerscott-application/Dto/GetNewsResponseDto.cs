namespace walkerscott_application.Dto
{
    public class GetNewsResponseDto
    {
        public List<NewsArticleDto>? Articles { get; set; }
        public string? PrevPageLink { get; set; }
        public string? NextPageLink { get; set; }
    }
}
