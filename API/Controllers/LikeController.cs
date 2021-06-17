using Application;
using Application.Commands.Like;
using Application.DataTransfer;
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
	public class LikeController : ControllerBase
	{

		private readonly UseCaseExecutor _executor;

		public LikeController(UseCaseExecutor executor)
		{
			_executor = executor;
		}

		// GET: api/<LikeController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<LikeController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<LikeController>
		[HttpPost]
		public IActionResult Post([FromBody] LikedDto dto, [FromServices] ICreateLike command)
		{
			_executor.ExecuteCommand(command, dto);
			return StatusCode(201);

		}

		// PUT api/<LikeController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<LikeController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id, [FromServices] IDeleteLike command)
		{
			_executor.ExecuteCommand(command, id);
			return StatusCode(204);
		}
	}
}
