using JWTAPI.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IAuthJwt authJwt;
        public StudentController(IAuthJwt authJwt)
        {
            this.authJwt = authJwt;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpGet]
        [Route("Ersad/Test")]
        public IActionResult Authentication(string UserName,string Password)
        {
            var token = authJwt.Authentication(UserName, Password);
            if(token==null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }
        }
        [Authorize]
        [HttpGet]
        [AllowAnonymous]
        [Route("Ersad/ETest")]
        public IActionResult Test()
        {
            string Test = "Ersad";
            Boolean x = Test.Contains("egg", StringComparison.Ori); ;
            return Ok("Ersad");
        }
    }
}
