using Back.Models.Entities;
using Back.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserListsController : ControllerBase
    {
        private readonly IUserListService _userListService;

        public UserListsController(IUserListService userListService)
        {
            _userListService = userListService;
        }

        [HttpPost("{type}/{productId}")]
        //in real life wish lists and baskets should probably have each their own routes
        public IActionResult AddProductToList([FromRoute] UserListType type, [FromRoute] int productId)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (userEmail == null)
            {
                return BadRequest("User email not found in claims.");
            }
            var userList = _userListService.AddProductToList(userEmail, productId, type);
            if (userList == null)
            {
                return NotFound("Product not found.");
            }
            return Ok(userList);
        }

        [HttpGet("{type}")]
        public IActionResult GetList([FromRoute] UserListType type)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (userEmail == null)
            {
                return BadRequest("User email not found in claims.");
            }
            var userList = _userListService.GetList(userEmail, type);
            if (userList == null)
            {
                return Ok(new UserList { UserEmail = userEmail, Type = type, Products = new List<Product>() });
            }
            return Ok(userList);
        }

        [HttpDelete("{type}/{productId}")]
        public IActionResult RemoveProductFromList([FromRoute] UserListType type, [FromRoute] int productId)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (userEmail == null)
            {
                return BadRequest("User email not found in claims.");
            }
            var removed = _userListService.RemoveProductFromList(userEmail, productId, type);
            if (!removed)
            {
                return NotFound("Product not found in the list.");
            }
            return NoContent();
        }

        [HttpDelete("{type}")]
        public IActionResult ClearList([FromRoute] UserListType type)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (userEmail == null)
            {
                return BadRequest("User email not found in claims.");
            }
            _userListService.ClearList(userEmail, type);
            return NoContent();
        }
    }
}