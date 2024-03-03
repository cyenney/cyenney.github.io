using SentimentAnalysis;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public bool Sentiment { get; set; } //false = negative, true = positive

        public static Comment CreateValidComment(CommentRequest commentRequest)
        {
            if (commentRequest.CustomerId != Guid.Empty && (commentRequest.Comment != null && commentRequest.Comment != string.Empty))
            {
                Comment validComment = new()
                {
                    Id = Guid.NewGuid(),
                    CustomerId = commentRequest.CustomerId,
                    Text = commentRequest.Comment,
                    CreatedDate = DateTime.Now,
                    Name = commentRequest.Name,
                    PhoneNumber = commentRequest.PhoneNumber,
                    Email = commentRequest.Email
                };
                var mlLogic = new Logic();
                var sentimentResponse = mlLogic.GetSentimentAnalysis(validComment.Text);
                validComment.Sentiment = sentimentResponse.Prediction == "Negative" ? false : true;

                return validComment;
            }
            return null;
        }
    }

    public class CommentRequest
    {
        public Guid CustomerId { get; set; }
        public string? Comment { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }

    
}
