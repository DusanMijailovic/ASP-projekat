using Application;
using Application.Commands.Comment;
using Application.DataTransfer;
using Application.Queries.Comment;
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
	public class CommentController : ControllerBase
	{

		private readonly UseCaseExecutor _executor;

		public CommentController(UseCaseExecutor executor)
		{
			_executor = executor;
		}

		// GET: api/<CommentController>
		[HttpGet]
		public IActionResult Get([FromQuery] CommentSearch search, [FromServices] IGetComments query)
		{
			return Ok(_executor.ExecuteQuery(query, search));
		}

		// GET api/<CommentController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id, [FromServices] IGetComment query)
		{
			return Ok(_executor.ExecuteQuery(query, id));
		}

		// POST api/<CommentController>
		[HttpPost]
		public IActionResult Post([FromBody] CreateCommentDto dto, [FromServices] ICreateComment command)
		{
			_executor.ExecuteCommand(command, dto);
			return StatusCode(StatusCodes.Status201Created);
		}

		// PUT api/<CommentController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] UpdateCommentDto dto, [FromServices] IUpdateComment command)
		{
			dto.Id = id;
			_executor.ExecuteCommand(command, dto);
			return NoContent();
		}

		// DELETE api/<CommentController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id, [FromServices] IDeleteComment command)
		{
			_executor.ExecuteCommand(command, id);
			return NoContent();

		}
	}
}
