using Application.Commands.Category;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using FluentValidation;
using Implementation.Validators.Category;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.Category
{
	public class EfDeleteCategory : IDeleteCategory
	{

		private readonly SportskeContext _context;
		
		private readonly IMapper _mapper;

		public EfDeleteCategory(SportskeContext context, IMapper mapper)
		{
			_context = context;
			
			_mapper = mapper;
		}

		public int Id => 2;

		public string Name => "Deleting category";

		public void Execute(int request)
		{
			var category = _context.Categories.Include(x => x.Articles).FirstOrDefault(x => x.Id == request);

			if (category == null)
			{
				throw new EntityNotFoundException(request, typeof(Domain.Entities.Category));
			}

			if (category.Articles.Any())
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
