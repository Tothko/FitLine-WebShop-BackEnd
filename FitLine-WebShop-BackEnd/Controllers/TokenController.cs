using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Application_Services;
using AppCore.Helpers;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitLine_WebShop_BackEnd.Controllers
{
    [Route("/token")]
    public class TokenController : Controller
    {
        private IAdminService AdminServ;
        private IAuthenticationHelper authenticationHelper;

        public TokenController(IAdminService AdminService, IAuthenticationHelper authService)
        {
            AdminServ = AdminService;
            authenticationHelper = authService;
        }


        [HttpPost]
        public IActionResult Login([FromBody]LoginInputModel model)
        {
            var Admin = AdminServ.ReadAdmins().FirstOrDefault(u => u.Username == model.Username);

            // check if username exists
            if (Admin == null)
                return Unauthorized();

            // check if password is correct
            if (!authenticationHelper.VerifyPasswordHash(model.Password, Admin.PasswordHash, Admin.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = Admin.Username,
                token = authenticationHelper.GenerateToken(Admin)
            });
        }

    }
}
