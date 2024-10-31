using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Robbochinni.Driver.Business.Operations;
using Robbochinni.Driver.Mag.Input;
using Robbochinni.Driver.Mag.Insertion;
using Robbochinni.Driver.Mag.Statics;
using Robbochinni.Driver.Mag.ValueObjects;
using Robbochinni.Driver.Mag.View;

namespace Robbochinni.Driver.API.Controllers.v1
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthManager _authManager;
        private readonly CarManager _carManager;
        public AuthController(AuthManager authManager, CarManager carManager)
        {
            _authManager = authManager;
            _carManager = carManager;
        }

        [HttpPost]
        //[EnableCors("allowAll")]
        public async Task<IActionResult> Signup(AddUserView addUser)
        {
            var result =  await _authManager.Signup(new AddUser(
                    addUser.FirstName,
                    addUser.LastName,
                    addUser.Email,
                    new Secret(addUser.Password),
                    RandomGenerator.Code,
                    addUser.Phone,
                    Guid.Parse("8176db54-ae70-4200-b686-574c5b9be5eb"),
                    true
                ));

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("login/byuser")]
        public async Task<IActionResult> Login(UserLoginView user)
        {
            var result = await _authManager.Login(new UserLogin(user.Mobile, new Secret(user.Password)));

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _authManager.GetAll();
            return StatusCode(result.StatusCode, result);
        }

        //[HttpGet("bydevice/{username}/login")]
        //public async Task<IActionResult> Login(string? username, string password)
        //{
        //    var result = await _authManager.Login(new UserLogin(username, password));

        //    return StatusCode(result.StatusCode, result);
        //}
    }
}
