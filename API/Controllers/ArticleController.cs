using Application;
using Application.Commands.Article;
using Application.DataTransfer;
using Application.Queries.Article;
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
	public class ArticleController : ControllerBase
	{

		private readonly UseCaseExecutor _executor;

		public ArticleController(UseCaseExecutor executor)
		{
			_executor = executor;
		}

		// GET: api/<ArticleController>
		[HttpGet]
		public IActionResult Get([FromQuery] ArticleSearch search, [FromServices] IGetArticles query)
		{
			return Ok(_executor.ExecuteQuery(query, search));
		}

		// GET api/<ArticleController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id, [FromServices] IGetArticle query)
		{
			return Ok(_executor.ExecuteQuery(query, id));
		}

		// POST api/<ArticleController>
		[HttpPost]
		public IActionResult Post([FromBody] CreateArticleDto dto, [FromServices] ICreateArticle command)
		{
			_executor.ExecuteCommand(command, dto);
			return StatusCode(StatusCodes.Status201Created);
		}

		// PUT api/<ArticleController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] UpdateArticleDto dto, [FromServices] IUpdateArticle command)
		{
			dto.Id = id;
			_executor.ExecuteCommand(command, dto);
			return NoContent();
		}

		// DELETE api/<ArticleController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id, [FromServices] IDeleteArticle command)
		{
			_executor.ExecuteCommand(command, id);
			return NoContent();
		}
	}
}
