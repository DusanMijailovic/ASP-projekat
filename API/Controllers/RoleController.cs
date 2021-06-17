using Application;
using Application.Commands.Role;
using Application.DataTransfer;
using Application.Queries.Role;
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
	public class RoleController : ControllerBase
	{
		private readonly UseCaseExecutor _executor;

		public RoleController(UseCaseExecutor executor)
		{
			_executor = executor;
		}

		// GET: api/<RoleController>
		[HttpGet]
		public IActionResult Get([FromQuery] RoleSearch search, [FromServices] IGetRoles query)
		{
			return Ok(_executor.ExecuteQuery(query, search));
		}

		// GET api/<RoleController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id, [FromServices] IGetRole query)
		{
			return Ok(_executor.ExecuteQuery(query, id));
		}

		// POST api/<RoleController>
		[HttpPost]
		public IActionResult Post([FromBody] RoleDto dto, [FromServices] ICreateRole command)
		{
			_executor.ExecuteCommand(command, dto);
			return StatusCode(StatusCodes.Status201Created);
		}

		// PUT api/<RoleController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] RoleDto dto, [FromServices] IUpdateRole command)
		{
			dto.Id = id;
			_executor.ExecuteCommand(command, dto);
			return NoContent();

		}

		// DELETE api/<RoleController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id, [FromServices] IDeleteRole command)
		{
			_executor.ExecuteCommand(command, id);
			return NoContent();
		}
	}
}
