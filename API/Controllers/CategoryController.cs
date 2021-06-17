using Application;
using Application.Commands.Category;
using Application.DataTransfer;
using Application.Queries.Category;
using Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{

		private readonly UseCaseExecutor _executor;
		
		public CategoryController(UseCaseExecutor executor)
		{
			_executor = executor;
			
		}

		// GET: api/<CategoryController>
		[HttpGet]
		public IActionResult Get([FromQuery] CategorySearch search, [FromServices] IGetCategories query)
		{
			return Ok(_executor.ExecuteQuery(query, search));
		}

		// GET api/<CategoryController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id, [FromServices] IGetCategory query)
		{
			return Ok(_executor.ExecuteQuery(query, id));
		}

		// POST api/<CategoryController>
		[HttpPost]
		public IActionResult Post([FromBody] CategoryDto dto, [FromServices] ICreateCategory command)
		{
			_executor.ExecuteCommand(command, dto);
			return StatusCode(StatusCodes.Status201Created);
		}

		// PUT api/<CategoryController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] CategoryDto dto, [FromServices] IUpdateCategory command)
		{
			dto.Id = id;
			_executor.ExecuteCommand(command, dto);
			return NoContent();
		}

		// DELETE api/<CategoryController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id, [FromServices] IDeleteCategory command)
		{
			_executor.ExecuteCommand(command, id);
			return NoContent();
		}
	}
}
