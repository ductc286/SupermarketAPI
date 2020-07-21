using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.Contants;
using Supermarket.Core.ViewModels;
using SupermarketAPI.DataAccessLayer.IRepositories;
using SupermarketAPI.Service;

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
            //var d = _userService.GetAll();
            var users = "test";
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(LoginStaffViewModel loginStaffViewModel)
        {
            if (!loginStaffViewModel.IsValidModel())
            {
                return BadRequest(new { message = loginStaffViewModel.Error });
            }
            var user = _userService.Authenticate(loginStaffViewModel.Account, loginStaffViewModel.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}
