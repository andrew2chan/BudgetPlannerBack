using BudgetPlanner.DTO;
using BudgetPlanner.Interfaces;
using BudgetPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace BudgetPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] User user)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                MonthlyIncome = 0,
                BudgetItems = new List<BudgetItem>()
            };

            var userCreated = _userRepository.CreateUser(newUser);

            if(!userCreated)
            {
                ModelState.AddModelError("Error", "User exists already");
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public IActionResult DeleteUser(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _userRepository.DeleteUserById(id);

            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ModifyUser([FromBody] UserDTO user)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var updateUserSuccess = _userRepository.ModifyUser(user);

            if(!updateUserSuccess)
            {
                ModelState.AddModelError("Error", "User id does not exist");
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetUserByCredentials([FromBody] CredentialsDTO credentials)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _userRepository.GetUserByEmail(credentials);

            if(user == null)
            {
                ModelState.AddModelError("Error", "User does not exist");
                return BadRequest(ModelState);
            }

            return Ok(user);
        }

        private bool ValidateEmail(string email)
        {
            String pattern = @"^[A-Z0-9+_.-]+@[A-Z0-9-]+[.][A-Z]+$"; //checks this pattern X@X.c

            return !Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        private bool ValidatePassword(string password)
        {
            var passwordIsValid = true;

            String pattern = @"\s{1,}";

            if (password.Length == 0 || Regex.IsMatch(password, pattern, RegexOptions.IgnoreCase))
                passwordIsValid = false;

            return passwordIsValid;
        }

        private bool ValidateName(string name)
        {

            var nameIsValid = false;

            String pattern = @"[A-Z]{1,}";

            if (Regex.IsMatch(name, pattern, RegexOptions.IgnoreCase))
                nameIsValid = true;

            return nameIsValid;
        }
    }
}
