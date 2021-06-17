using Application.Commands.Category;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using FluentValidation;
using Implementation.Validators.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Category
{
	public class EfUpdateCategory : IUpdateCategory
	{

		private readonly SportskeContext _context;
		private readonly UpdateCategoryValidator _validator;
		private readonly IMapper _mapper;
		public EfUpdateCategory(SportskeContext context, UpdateCategoryValidator validator, IMapper mapper)
		{
			_context = context;
			_validator = validator;
			_mapper = mapper;
		}

		public int Id => 3;

		public string Name => "Updating category";

		public void Execute(CategoryDto request)
		{
			var category = _context.Categories.Find(request.Id);

			if (category == null)
			{
				throw new EntityNotFoundException(request.Id, typeof(Domain.Entities.Category));
			}

			_validator.ValidateAndThrow(request);

			_mapper.Map(request, category);
			_context.SaveChanges();

		}
	}
}
