using Application.Commands.Photo;
using Application.Exceptions;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.Photo
{
	public class EfDeletePhoto : IDeletePhoto
	{
		private readonly SportskeContext _context;

		public EfDeletePhoto(SportskeContext context)
		{
			_context = context;
		}

		public int Id => 33;

		public string Name => "Delete photo";

		public void Execute(int request)
		{
			

			var photo = _context.Photos.Include(x=> x.Articles).FirstOrDefault(x => x.Id == request);
			if (photo == null)
			{
				throw new EntityNotFoundException(request, typeof(Domain.Entities.Photo));
			}

			if(photo.Articles.Any())
			photo.DeletedAt = DateTime.Now;
			photo.IsDeleted = true;
			photo.IsActive = false;
			_context.SaveChanges();


			var category = _context.Categories.Include(x => x.Articles).FirstOrDefault(x => x.Id == request);

			if (category == null)
			{
				throw new EntityNotFoundException(request, typeof(Domain.Entities.Category));
			}

			if (category.Articles.Any(x=>x.PhotoId == request))
			{
				throw new ConflictException("You can't delete this resource because it is used in the system");
			}

			category.IsActive = false;
			category.IsDeleted = true;
			category.DeletedAt = DateTime.Now;

			_context.SaveChanges();





		}
	}
}
