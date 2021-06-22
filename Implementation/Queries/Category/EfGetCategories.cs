using Application.DataTransfer;
using Application.Queries;
using Application.Queries.Category;
using Application.Searches;
using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Category
{
	public class EfGetCategories : IGetCategories
	{
		private readonly SportskeContext _context;
		private readonly IMapper _mapper;
		public EfGetCategories(SportskeContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public int Id => 4;

		public string Name => "Get Categories";

		public PagedResponse<CategoryDto> Execute(CategorySearch search)
		{
			var query = _context.Categories.AsQueryable();

			if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
			{
				query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
			}
			var skipcount = search.PerPage * (search.Page - 1);

			var categories = new PagedResponse<CategoryDto>
			{
				CurrentPage = search.Page,
				ItemsPerPage = search.PerPage,
				TotalCount = query.Count(),
				Items = query.Skip(skipcount).Take(search.PerPage).Select(x => new CategoryDto
				{
					Id = x.Id,
					Name = x.Name
				})

			};


			return categories;

		}
	}
}
