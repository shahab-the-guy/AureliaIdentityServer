using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aurelia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize]
    public class SecureController : ControllerBase
    {

		public IActionResult Get()
		{
			var result = new[] { "Aurelia" , "Angular" , "Vue" , "React" };

			return Ok(result);
		}

    }
}