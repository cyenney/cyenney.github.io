using Microsoft.AspNetCore.Mvc;
using SentimentAnalysis;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SentimentAnalysisController : Controller
    {
        [HttpGet("get-analysis/{comment}")]
        public SentimentResponse GetAnalysis(string comment)
        {
            var sentimentAnalysisLogic = new Logic();
            var response = sentimentAnalysisLogic.GetSentimentAnalysis(comment);
            return response;
        }
    }
}
