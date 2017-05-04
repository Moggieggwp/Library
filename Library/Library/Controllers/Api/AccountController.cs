using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using EasyFlights.Web.Infrastructure;
using Library.Data.Entities;
using Library.ViewModels;

namespace Library.Controllers.Api
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly IAuthenticationManager authenticationManager;

        private readonly IApplicationUserManager applicationUserManager;

        public AccountController(IApplicationUserManager applicationUserManager, IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
            this.applicationUserManager = applicationUserManager;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [HttpGet]
        public async Task<IHttpActionResult> SignUp()
        {
            var model = new RegisterViewModel
            {
                UserEmail = "test@test.com",
                UserName = "test",
                UserSurname = "test",
                UserPassword = "Password",
                UserPhone = "123456789"
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser user = new ApplicationUser()
            {
                UserName = model.UserEmail,
                Email = model.UserEmail,
                FirstName = model.UserName,
                LastName = model.UserSurname,
                PhoneNumber = model.UserPhone
            };

            IdentityResult result = await this.applicationUserManager.CreateAsync(user, model.UserPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            ClaimsIdentity claim = await this.applicationUserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            this.authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);

            var a = IsAuthenticated();
            return Ok();
        }

        [Route("IsAuthenticated")]
        [HttpGet]
        public bool IsAuthenticated()
        {
            return User.Identity.IsAuthenticated;
        }

        // POST api/Account/Login
        [Route("SignIn")]
        [HttpPost]
        public async Task<IHttpActionResult> SignIn([FromBody] LoginViewModel model)
        {
            this.authenticationManager.SignOut();
            var user = await this.applicationUserManager.FindAsync(model.UserEmail, model.UserPassword);
            if (user == null)
            {
                return GetErrorResult(IdentityResult.Failed());
            }

            ClaimsIdentity claim = await this.applicationUserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            this.authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
            return Ok();
        }

        [Route("Login")]
        [HttpGet]
        public async Task<IHttpActionResult> Login(string UserEmail, string UserPassword)
        {
            this.authenticationManager.SignOut();
            var user = await this.applicationUserManager.FindAsync(UserEmail, UserPassword);
            if (user == null)
            {
                return GetErrorResult(IdentityResult.Failed());
            }

            ClaimsIdentity claim = await this.applicationUserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            this.authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
            return Ok();
        }

        // POST api/Account/Logout
        [Route("SignOut")]
        [HttpGet]
        public IHttpActionResult SignOut()
        {
            this.authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                applicationUserManager?.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}