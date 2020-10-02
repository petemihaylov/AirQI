using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiJwt.Data;
using ApiJwt.Models;
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
            if (_user != null && _user.FirstName != null && _user.Password != null)
            ***REMOVED***
                User user =  _repository.GetByUsernameAsync<User>(_user.FirstName).Result;
 
                if (user != null)
                ***REMOVED***
                    //create claims details based on the user information
                    var claims = new[] ***REMOVED***
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName)
                  ***REMOVED***;
 

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
 
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
 
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
               ***REMOVED***
                else
                ***REMOVED***
                    return BadRequest("Invalid credentials");
               ***REMOVED***
           ***REMOVED***
            else
            ***REMOVED***
                return BadRequest();
           ***REMOVED***
       ***REMOVED***

   ***REMOVED***
***REMOVED***
