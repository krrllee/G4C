using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterCloneBackend.Dto;
using TwitterCloneBackend.Services;
using TwitterCloneBackend.Services.Interfaces;

namespace TwitterCloneBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly ITweetService _tweetService;
        public TweetController(ITweetService tweetService)
        {
            _tweetService = tweetService;
        }

        [HttpPost]
        [Route("AddTweet")]
        [Authorize]
        public IActionResult AddTweet([FromBody] TweetDto tweetDto)
        {
            try
            {
                string username = User.Identity.Name;
                _tweetService.AddTweet(username, tweetDto);
                return Ok("Tweet added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetTweets")]
        [Authorize]
        public IActionResult GetTweetsFromUser()
        {
            string username = User.Identity.Name;
            var res = _tweetService.GetTweetsByUser(username);


            return Ok(res);
        }

        [HttpDelete]
        [Route("DeleteTweet")]
        [Authorize]
        public IActionResult DeleteTweet(string id)
        {
            try
            {
                var tweetId = int.Parse(id);
                _tweetService.DeleteTweet(tweetId);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
