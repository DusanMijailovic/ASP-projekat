using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.Category;
using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Queries.Category
{
	public class EfGetCategory : IGetCategory
	{

		private readonly SportskeContext _context;
		private readonly IMapper _mapper;
		public EfGetCategory(SportskeContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public int Id => 5;

		public string Name => "Category search";

		public CategoryDto Execute(int search)
		{
			var category = _context.Categories.Find(search);

			if (category == null)
			{
				throw new EntityNotFoundException(search, typeof(Domain.Entities.Category));
			}

			return _mapper.Map<CategoryDto>(category);

		

		}
	}
}
