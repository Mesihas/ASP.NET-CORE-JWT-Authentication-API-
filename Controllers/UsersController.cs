using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;

namespace WebApi.Controllers
{
  [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
          var user = _userService.Authenticate(userParam.Username, userParam.Password);

          if (user == null) { return BadRequest(new { message = "Username or password is wrong" }); }

          string[] roles = new string[1];
          roles[0] = "admin";

          string[] shortcuts = new string[4];
          shortcuts[0] = "calendar";
          shortcuts[1] = "mail";
          shortcuts[2] = "contacts";
          shortcuts[3] = "todo";

          var data = new User {
                          DisplayName = "Alejandro",
                          PhotoURL = "assets/images/avatars/Velazquez.jpg",
                          Email = "johndoe@withinpixels.com",
                          Shortcuts = shortcuts,
                          Token = user.Token,
                          FirstName = "Corre Gil"
          };
          


          return Ok(new {
            role = roles,
            data = data
          });

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users =  _userService.GetAll();
            return Ok(users);
        }
    }

}

//  const initialState = {
//  role: [],//guest
//  data: {
//      'displayName': 'John Doe',
//      'photoURL'   : 'assets/images/avatars/Velazquez.jpg',
//      'email'      : 'johndoe@withinpixels.com',
//      shortcuts    : [
//          'calendar',
//          'mail',
//          'contacts',
//          'todo'
//      ]
//}