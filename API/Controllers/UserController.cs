using Application;
using Application.Commands.User;
using Application.DataTransfer;
using Application.Queries.User;
using Application.Searches;
using Microsoft.AspNetCore.Http;
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
	public class UserController : ControllerBase
	{

		private readonly UseCaseExecutor _executor;

		public UserController(UseCaseExecutor executor)
		{
			_executor = executor;
		}

		// GET: api/<UserController>
		[HttpGet]
		public IActionResult Get([FromQuery] UserSearch search, [FromServices] IGetUsers query)
		{
			return Ok(_executor.ExecuteQuery(query, search));
		}

		// GET api/<UserController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id, [FromServices] IGetUser query)
		{
			return Ok(_executor.ExecuteQuery(query, id));
		}

		// POST api/<UserController>
		[HttpPost]
		public IActionResult Post([FromBody] CreateUserDto dto, [FromServices] ICreateUser command)
		{
			_executor.ExecuteCommand(command, dto);
			return StatusCode(StatusCodes.Status201Created);

		}

		// PUT api/<UserController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] UserDto dto, [FromServices] IUpdateUser command)
		{
			dto.Id = id;
			_executor.ExecuteCommand(command, dto);
			return NoContent();
		}

		// DELETE api/<UserController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id, [FromServices] IDeleteUser command)
		{
			_executor.ExecuteCommand(command, id);
			return NoContent();
		}
	}
}
