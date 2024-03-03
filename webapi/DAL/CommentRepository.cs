using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.DAL
{
    public class CommentRepository 
    {
        private readonly SurveySaysDbContext _context;
        public CommentRepository(SurveySaysDbContext dbContext) 
        { 
            _context = dbContext;
        }
        public List<Comment> comments = new List<Comment>()
        {
            new Comment() {Id = Guid.Parse("bfe84e65-6568-4d44-97d2-84e5a2bfbcdc"), CreatedDate = DateTime.Now, Text = "This place was awesome!",
            CustomerId = Guid.Parse("16132c8e-4a88-46d9-9610-0be91fb2fbc0")},
            new Comment(){ Id = Guid.Parse("073a4d0c-8d84-4127-83e0-1a1f672757f3"), CreatedDate = DateTime.Now, Text = "The waitress was rude.",
            CustomerId = Guid.Parse("16132c8e-4a88-46d9-9610-0be91fb2fbc0")}
        };

        public List<Comment> GetCustomerComments(Guid customerId)
        {
            return comments.Where(x=>x.Id == customerId).ToList();
        }

        public Guid CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment.Id;
        }
    }
}
