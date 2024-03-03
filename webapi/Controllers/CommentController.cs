using Microsoft.AspNetCore.Mvc;
using webapi.DAL;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : Controller
    {
        public CommentRepository _commentRepository;
        public CommentController(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("get-comments/{id}")]
        public List<Comment> GetCustomerComments(Guid id)
        {
            var comments = _commentRepository.GetCustomerComments(id);
            return comments;
        }

        [HttpPost("create")]
        public ActionResult<Guid> SaveComment(CommentRequest commentRequest)
        {
            Comment validComment = Comment.CreateValidComment(commentRequest);
            return _commentRepository.CreateComment(validComment);
        }
    }
}
