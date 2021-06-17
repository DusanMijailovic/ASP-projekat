using Application;
using Application.Commands.Photo;
using Application.DataTransfer;
using Application.Queries.Photo;
using Application.Searches;
using DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PhotoController : ControllerBase
	{

		private readonly UseCaseExecutor _executor;
		private readonly SportskeContext _context;

		public PhotoController(SportskeContext context, UseCaseExecutor executor)
		{
			_context = context;
			_executor = executor;
		}

		// GET: api/<PhotoController>
		[HttpGet]
		public IActionResult Get([FromQuery] PhotoSearch dto, [FromServices] IGetPhoto query)
		{

			return Ok(_executor.ExecuteQuery(query, dto));
		}

		

		// POST api/<PhotoController>
		[HttpPost]
		public IActionResult Post([FromForm] UploadImageDto dto)
		{
			var guid = Guid.NewGuid();
			var extension = Path.GetExtension(dto.Image.FileName);

			var newFileName = guid + extension;

			var path = Path.Combine("wwwroot", "images", newFileName);

			using (var fileStream = new FileStream(path, FileMode.Create))
			{
				dto.Image.CopyTo(fileStream);
			}

			var photo = new Photo
			{
				Src = newFileName
			};
			_context.Photos.Add(photo);
			_context.SaveChanges();
			return StatusCode(StatusCodes.Status201Created);

		}

		

		// DELETE api/<PhotoController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id, [FromServices] IDeletePhoto command)
		{
			_executor.ExecuteCommand(command, id);
			return NoContent();

		}
	}
}
