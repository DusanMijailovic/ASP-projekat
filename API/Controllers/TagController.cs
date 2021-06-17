using Application;
using Application.Commands.Tag;
using Application.DataTransfer;
using Application.Queries.Tag;
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
	public class TagController : ControllerBase
	{
		private readonly UseCaseExecutor _executor;

		public TagController(UseCaseExecutor executor)
		{
			_executor = executor;
		}

		// GET: api/<TagController>
		[HttpGet]
		public IActionResult Get([FromServices] IGetTags query, [FromQuery] TagSearch search)
		{
			return Ok(_executor.ExecuteQuery(query, search));
		}

		// GET api/<TagController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id, [FromServices] IGetTag query)
		{
			return Ok(_executor.ExecuteQuery(query, id));
		}

		// POST api/<TagController>
		[HttpPost]
		public IActionResult Post([FromBody] TagDto dto, [FromServices] ICreateTag command)
		{
			_executor.ExecuteCommand(command, dto);
			return StatusCode(StatusCodes.Status201Created);
		}

		// PUT api/<TagController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] TagDto dto, [FromServices] IUpdateTag command)
		{

			dto.Id = id;
			_executor.ExecuteCommand(command, dto);
			return NoContent();
		}

		// DELETE api/<TagController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id, [FromServices] IDeleteTag command)
		{
			_executor.ExecuteCommand(command, id);
			return NoContent();
		}
	}
}
