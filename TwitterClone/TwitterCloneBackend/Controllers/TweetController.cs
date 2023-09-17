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

        [HttpPost]
        [Route("DeleteTweet")]
        [Authorize]
        public IActionResult DeleteTweet(int id)
        {
            try
            {
                var tweetId = id;
                _tweetService.DeleteTweet(tweetId);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateTweet")]
        [Authorize]
        public IActionResult UpdateTweet(string id, [FromBody]TweetDto tweetDto)
        {
            try
            {
                var tweetId = int.Parse(id);
                _tweetService.UpdateTweet(tweetId, tweetDto);
                return NoContent(); // Successful update returns 204 No Content
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Handle errors appropriately
            }
        }

        [HttpPost]
        [Route("AddLike")]
        [Authorize]
        public IActionResult AddLike([FromBody]LikeDto likeDto)
        {
            try
            {
                var username = User.Identity.Name;
                _tweetService.AddLike(likeDto,username);
                return Ok("Like added.");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("RemoveLike")]
        [Authorize]
        public IActionResult RemoveLike([FromBody]LikeDto likeDto)
        {
            try
            {
                _tweetService.RemoveLike(likeDto);
                return Ok("Like removed successfully.");

            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("AddComment")]
        [Authorize]
        public IActionResult AddComment([FromBody]CommentDto commentDto)
        {
            try
            {
                var username = User.Identity.Name;
                _tweetService.AddComment(username, commentDto);
                return Ok();
            }
            catch( Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("DeleteComment")]
        [Authorize]
        public IActionResult DeleteComment(string id)
        {
            try
            {
                //var username = User.Identity.Name;

                _tweetService.DeleteComment(int.Parse(id));
                return Ok("Comment deleted successfully.");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("UpdateComment")]
        [Authorize]
        public IActionResult UpdateComment([FromBody]UpdateCommDto commentDto)
        {
            try
            {
                var username = User.Identity.Name;
                _tweetService.UpdateComment(username, commentDto);
                return Ok("Comment updated successfully.");

            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");

            }

        }

    }
}
