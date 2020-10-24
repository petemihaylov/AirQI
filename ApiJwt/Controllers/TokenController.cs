using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiJwt.Data;
using ApiJwt.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ApiJwt.Controllers
***REMOVED***

    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    ***REMOVED***
        public IConfiguration _configuration;
        private readonly IEFRepository _repository;

        public TokenController(IConfiguration configuration, IEFRepository repository)
        ***REMOVED***
            this._configuration = configuration;
            this._repository = repository;
       ***REMOVED***

        [HttpPost]
        public IActionResult Post(User _user)
        ***REMOVED***
            if (_user != null && _user.Username != null && _user.Password != null)
            ***REMOVED***
                User user = _repository.GetByUserAsync<User>(_user.Username, _user.Password).Result;

                if (user != null)
                ***REMOVED***
                    //create claims details based on the user information
                    var claims = new[] ***REMOVED***
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Username", user.Username),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName),
                    new Claim("UserRole", user.UserRole.ToString())
                  ***REMOVED***;


                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                    
                    var responseObj = new UserDto
                    ***REMOVED***
                        Id = user.Id,
                        Username = user.Username,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserRole = user.UserRole.ToString(),
                        accessToken = jwt
                   ***REMOVED***;

                    return Ok(responseObj);
               ***REMOVED***
                else
                ***REMOVED***
                    return BadRequest(new ***REMOVED*** message = "Invalid credentials"***REMOVED***);
               ***REMOVED***
           ***REMOVED***
            else
            ***REMOVED***
                return BadRequest(new ***REMOVED*** message = "Username or password is incorrect"***REMOVED***);
           ***REMOVED***
       ***REMOVED***

   ***REMOVED***
***REMOVED***
