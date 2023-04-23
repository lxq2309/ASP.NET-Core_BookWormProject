namespace BookWormProject.DTOs
{
    public class CommentListDTO
    {
        public CommentListDTO(IEnumerable<CommentDTO> comments, PageInfoDTO pageInfo)
        {
            Comments = comments;
            PageInfo = pageInfo;
        }

        public IEnumerable<CommentDTO> Comments { get; set; }
        public PageInfoDTO PageInfo { get; set; }
    }
}
