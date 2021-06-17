using Application.Commands.Category;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using FluentValidation;
using Implementation.Validators.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Category
{
	public class EfCreateCategory : ICreateCategory
	{
		private readonly SportskeContext _context;
		private readonly CreateCategoryValidator _validator;
		private readonly IMapper _mapper;


		public EfCreateCategory(SportskeContext context, CreateCategoryValidator validator, IMapper mapper)
		{
			_context = context;
			_validator = validator;
			_mapper = mapper;
		}

		public int Id => 1;

		public string Name => "Create new category";



		public void Execute(CategoryDto request)
		{
			_validator.ValidateAndThrow(request);
			_context.Categories.Add(_mapper.Map<Domain.Entities.Category>(request));
			_context.SaveChanges();
		}
	}
}
