using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReactDemo.Data;
using ReactDemo.TokenHelper;
using ReactDemoWebApp.Models;

namespace ReactDemoWebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JsonResponse _jsonResponse;
        private readonly IHttpContextAccessor _httpContext;

        public AccountController(UserManager<User> userManager,
            IHttpContextAccessor httpContext,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContext = httpContext;
            _roleManager = roleManager;
            _jsonResponse = new JsonResponse();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginModel inputModel)
        {
            try
            {
                #region Helper
                //const string _adminRoleName = "Admin";
                //string _adminEmail = "abh@narola.email";
                //string _adminPassword = "Abh@123456";

                //string[] _defaultRoles = new string[] { _adminRoleName, "Customer" };

                //foreach (var role in _defaultRoles)
                //{
                //    if (!await _roleManager.RoleExistsAsync(role))
                //    {
                //        await _roleManager.CreateAsync(new IdentityRole(role));
                //    }
                //}

                //var adminUsers = await _userManager.GetUsersInRoleAsync(_adminRoleName);

                //if (!adminUsers.Any())
                //{
                //    var adminUser = new User()
                //    {
                //        Email = _adminEmail,
                //        UserName = _adminEmail,
                //        FirstName = "Abh",
                //        LastName = "Narola",
                //    };

                //    var result = await _userManager.CreateAsync(adminUser, _adminPassword);
                //    await _userManager.AddToRoleAsync(adminUser, _adminRoleName);
                //} 
                #endregion

                if (!ModelState.IsValid)
                    return _jsonResponse.GenerateJsonResult(false, "Invalid Model");

                var result = await _signInManager.PasswordSignInAsync(inputModel.Email, inputModel.Password, false, false);

                if (!result.Succeeded)
                {
                    return _jsonResponse.GenerateJsonResult(false, "Invalid Login");
                }

                var user = await _userManager.FindByEmailAsync(inputModel.Email);

                var roles = await _userManager.GetRolesAsync(user);
                var role = (Role)Enum.Parse(typeof(Role), roles[0]);

                if (!user.EmailConfirmed)
                {
                    return _jsonResponse.GenerateJsonResult(false, "Please Confirm Your Email!!!");
                }

                //if (!user.IsActive || user.IsDeleted)
                //{
                //    return _jsonResponse.GenerateJsonResult(false, AccountMessage.AccountClosed);
                //}


                var currHttpScheme = _httpContext.HttpContext.Request.Scheme;
                var currHost = _httpContext.HttpContext.Request.Host.Value;
                var currHostUrl = currHttpScheme + "://" + currHost;

                var data = GenerateToken(roles, user, (int)role, currHostUrl);

                return _jsonResponse.GenerateJsonResult(true, "Login Successfully", data);
            }
            catch (Exception ex)
            {
                var error = ex;
                return _jsonResponse.GenerateJsonResult(false);
            }
        }


        #region Helper Methods

        private object GenerateToken(IList<string> roles, User user, int role, string currHostUrl)
        {
            var tokenBuilder = new JwtTokenBuilder()
                           .AddSecurityKey(JwtSecurityKey.Create())
                           .AddSubject("token authentication")
                           .AddIssuer("Fiver.Security.Bearer")
                           .AddAudience("Fiver.Security.Bearer")
                           .AddClaim("MembershipId", "111", roles)
                           .AddExpiry(360000)
                           .Build();
            var data = new
            {
                user.Id,
                Username = user.UserName,
                user.Email,
                Token = tokenBuilder.Value,
                FullName = user.FirstName + " " + user.LastName,
                user.FirstName,
                user.LastName,
                user.PhoneNumber,
                //Birthdate = user.Birthdate != null ? user.Birthdate.Value.ToShortDateString() : null,
                //user.Address,
                RoleId = role,
                //ProfilePic = user.ProfilePic == null ? null : currHostUrl + user.ProfilePic,
                //CoverPic = user.CoverPic == null ? null : currHostUrl + user.CoverPic,
                Validity = tokenBuilder.ValidTo
            };
            return data;
        }

        #endregion
    }
}