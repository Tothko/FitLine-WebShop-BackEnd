using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Application_Services;
using AppCore.Domain_Servives;
using AppCore.Helpers;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitLine_WebShop_BackEnd.Controllers
{
    [Route("/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        readonly IUserRepository _userRepository;
        readonly IAuthenticationHelper _authenticationHelper;

        public TokenController(IUserRepository userRepository, IAuthenticationHelper authenticationHelper)
        {
            _userRepository = userRepository;
            _authenticationHelper = authenticationHelper;
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginInputModel model)
        {
            var user = _userRepository.ReadUsers().FirstOrDefault(p => p.Username == model.Username);

            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!_authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                isAdmin = user.IsAdmin,
                token = _authenticationHelper.GenerateToken(user)
            });
        }
    }
}
