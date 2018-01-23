using AspNetCoreWebAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Git repo was tested 1/15

namespace AspNetCoreWebAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/test")]
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var model = new Message { Id = 1, Text = "Message, from the Get action." };

            return Ok(model);
        }
 
    }
}
