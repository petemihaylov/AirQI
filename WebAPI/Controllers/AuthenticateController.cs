using Microsoft.AspNetCore.Http;  
using Microsoft.AspNetCore.Identity;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.Extensions.Configuration;  
using Microsoft.IdentityModel.Tokens;  
using System;  
using System.Collections.Generic;  
using System.IdentityModel.Tokens.Jwt;  
using System.Security.Claims;  
using System.Text;  
using System.Threading.Tasks;  
using WebAPI.Authentication;

namespace WebAPI.Controllers  
***REMOVED***  
    [Route("api/[controller]")]  
    [ApiController]  
    public class AuthenticateController : ControllerBase  
    ***REMOVED***  
        private readonly UserManager<ApplicationUser> userManager;  
        private readonly RoleManager<IdentityRole> roleManager;  
        private readonly IConfiguration _configuration;  
  
        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)  
        ***REMOVED***  
            this.userManager = userManager;  
            this.roleManager = roleManager;  
            _configuration = configuration;  
       ***REMOVED***  
  
        [HttpPost]  
        [Route("login")]  
        public async Task<IActionResult> Login([FromBody] LoginModel model)  
        ***REMOVED***  
            var user = await userManager.FindByNameAsync(model.Username);  
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))  
            ***REMOVED***  
                var userRoles = await userManager.GetRolesAsync(user);  
  
                var authClaims = new List<Claim>  
                ***REMOVED***  
                    new Claim(ClaimTypes.Name, user.UserName),  
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),  
               ***REMOVED***;  
  
                foreach (var userRole in userRoles)  
                ***REMOVED***  
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));  
               ***REMOVED***  
  
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));  
  
                var token = new JwtSecurityToken(  
                    issuer: _configuration["JWT:ValidIssuer"],  
                    audience: _configuration["JWT:ValidAudience"],  
                    expires: DateTime.Now.AddHours(3),  
                    claims: authClaims,  
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)  
                    );  
  
                return Ok(new  
                ***REMOVED***  
                    token = new JwtSecurityTokenHandler().WriteToken(token),  
                    expiration = token.ValidTo  
               ***REMOVED***);  
           ***REMOVED***  
            return Unauthorized();  
       ***REMOVED***  
  
        [HttpPost]  
        [Route("register")]  
        public async Task<IActionResult> Register([FromBody] RegisterModel model)  
        ***REMOVED***  
            var userExists = await userManager.FindByNameAsync(model.Username);  
            if (userExists != null)  
                return StatusCode(StatusCodes.Status500InternalServerError, new Response ***REMOVED*** Status = "Error", Message = "User already exists!"***REMOVED***);  
  
            ApplicationUser user = new ApplicationUser()  
            ***REMOVED***  
                Email = model.Email,  
                SecurityStamp = Guid.NewGuid().ToString(),  
                UserName = model.Username  
           ***REMOVED***;  
            var result = await userManager.CreateAsync(user, model.Password);  
            if (!result.Succeeded)  
                return StatusCode(StatusCodes.Status500InternalServerError, new Response ***REMOVED*** Status = "Error", Message = "User creation failed! Please check user details and try again."***REMOVED***);  
  
            return Ok(new Response ***REMOVED*** Status = "Success", Message = "User created successfully!"***REMOVED***);  
       ***REMOVED***  
  
        [HttpPost]  
        [Route("register-admin")]  
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)  
        ***REMOVED***  
            var userExists = await userManager.FindByNameAsync(model.Username);  
            if (userExists != null)  
                return StatusCode(StatusCodes.Status500InternalServerError, new Response ***REMOVED*** Status = "Error", Message = "User already exists!"***REMOVED***);  
  
            ApplicationUser user = new ApplicationUser()  
            ***REMOVED***  
                Email = model.Email,  
                SecurityStamp = Guid.NewGuid().ToString(),  
                UserName = model.Username  
           ***REMOVED***;  
            var result = await userManager.CreateAsync(user, model.Password);  
            if (!result.Succeeded)  
                return StatusCode(StatusCodes.Status500InternalServerError, new Response ***REMOVED*** Status = "Error", Message = "User creation failed! Please check user details and try again."***REMOVED***);  
  
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))  
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));  
            if (!await roleManager.RoleExistsAsync(UserRoles.User))  
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));  
  
            if (await roleManager.RoleExistsAsync(UserRoles.Admin))  
            ***REMOVED***  
                await userManager.AddToRoleAsync(user, UserRoles.Admin);  
           ***REMOVED***  
  
            return Ok(new Response ***REMOVED*** Status = "Success", Message = "User created successfully!"***REMOVED***);  
       ***REMOVED***  
   ***REMOVED***  
***REMOVED***  