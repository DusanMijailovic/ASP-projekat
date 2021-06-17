using Application;
using Application.Queries.UseCaseLog;
using Application.Searches;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UseCaseLogController : ControllerBase
	{
		private readonly UseCaseExecutor _executor;

		public UseCaseLogController(UseCaseExecutor executor)
		{
			_executor = executor;
		}

		// GET: api/<UseCaseLogController>
		[HttpGet]
		public IActionResult Get([FromQuery] UseCaseLogSearch search, [FromServices] IGetUseCaseLog query)
		{
			return Ok(_executor.ExecuteQuery(query, search));
		}

		
	}
}
