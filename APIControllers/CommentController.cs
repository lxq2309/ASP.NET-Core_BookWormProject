using BookWormProject.Data.Services;
using BookWormProject.DTOs;
using BookWormProject.Models;
using BookWormProject.Utils.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BookWormProject.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;

        public CommentController(IArticleService articleService, ICommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }

        [HttpGet("get_comments_for_article")]
        public IActionResult GetCommentsForArticle(int articleId, int? page, int pageSize = 10)
        {
            var pagedComment = _articleService.GetCommentsForArticle(articleId).OrderByDescending(x => x.CommentId).ToPagedList(page ?? 1, pageSize);
            var commentsDTO = pagedComment.Select(x =>
            {
                var currentUser = _commentService.GetUserForComment(x.CommentId);
                return new CommentDTO()
                {
                    CommentId = x.CommentId,
                    Content = x.Content,
                    CreatedAt = x.CreatedAt,
                    TimeAgo = DateTimeHelper.ToTimeAgo(x.CreatedAt),
                    User = new UserDTO()
                    {
                        UserId = currentUser.UserId,
                        Avatar = currentUser.Avatar,
                        UserName = currentUser.UserName
                    }
                };
            });


            var pageInfoDTO = new PageInfoDTO
            {
                PageNumber = pagedComment.PageNumber,
                PageSize = pagedComment.PageSize,
                TotalItems = pagedComment.TotalItemCount,
                TotalPages = pagedComment.PageCount,
                HasPreviousPage = pagedComment.HasPreviousPage,
                HasNextPage = pagedComment.HasNextPage,
                NextPageUrl = Url.Action("GetCommentsForArticle", new { page = pagedComment.PageNumber + 1, pageSize }),
                PreviousPageUrl = Url.Action("GetCommentsForArticle", new { page = pagedComment.PageNumber - 1, pageSize })
            };

            var commentListDTO = new CommentListDTO(commentsDTO, pageInfoDTO);
            return Ok(commentListDTO);
        }

        [HttpPost("Post")]
        public IActionResult PostComment([FromBody] CommentDTO commentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = new Comment
            {
                Content = commentDto.Content,
                ArticleId = commentDto.ArticleId,
            };

            _commentService.AddComment(comment);

            return Ok(new { comment.CommentId });
        }


        [HttpDelete("Delete")]
        public bool Delete(int commentId)
        {
            var comment = _commentService.GetById(commentId);
            if (comment == null)
            {
                return false;
            }
            _commentService.DeleteComment(commentId);
            return true;
        }
    }
}
