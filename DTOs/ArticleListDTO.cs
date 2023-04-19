namespace BookWormProject.DTOs
{
    public class ArticleListDTO
    {
        public IEnumerable<ArticleDTO> Articles { get; set; }
        public PageInfoDTO PageInfo { get; set; }

        public ArticleListDTO(IEnumerable<ArticleDTO> articles, PageInfoDTO pageInfo)
        {
            Articles = articles;
            PageInfo = pageInfo;
        }
    }
}
