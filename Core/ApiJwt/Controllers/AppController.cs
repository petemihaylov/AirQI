using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
{
    [ApiController]
    [Route("/")]
    public class AppController : ControllerBase
    {
        public AppController(){}

        [HttpGet]
        public string Index()
        {
            return "Welcome to Jwt API!";
        }

    }
}
