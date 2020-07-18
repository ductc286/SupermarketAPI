using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.Contants;
using SupermarketAPI.Core.Entities;
using SupermarketAPI.DataAccessLayer.IRepositories;
using SupermarketAPI.Service;
using System.Linq;

namespace SupermarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private ICategoryRepository _categoryRepository;

        public UsersController(IUserService userService, ICategoryRepository categoryRepository)
        {
            _userService = userService;
            _categoryRepository = categoryRepository;

        }

        [Authorize(Roles = RoleConst.ADMIN)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var d = _userService.GetAll();
            var users = "test";
            return Ok(users);
        }

        [HttpGet("Test")]
        //[Route("Test")]
        public IActionResult GetTest(Category category)
        {
            var result = _categoryRepository.GetAll();
            var d = result.FirstOrDefault(c => c.CategoryId == 3);
            
            var users = "test";
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(string Username, string Password)
        {
            var user = _userService.Authenticate(Username, Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}
