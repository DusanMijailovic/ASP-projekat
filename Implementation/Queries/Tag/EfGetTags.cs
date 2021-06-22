using Application.DataTransfer;
using Application.Queries;
using Application.Queries.Tag;
using Application.Searches;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
	public class EfGetTags : IGetTags
	{
		private readonly SportskeContext _context;

		public EfGetTags(SportskeContext context)
		{
			_context = context;
		}

		public int Id => 12;

		public string Name => "Get tags";

		public PagedResponse<TagDto> Execute(TagSearch search)
		{
			var tags = _context.Tags.AsQueryable();
			if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
			{
				tags = tags.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
			}
			var skipCount = search.PerPage * (search.Page - 1);
			var tag = new PagedResponse<TagDto>
			{
				CurrentPage = search.Page,
				ItemsPerPage = search.PerPage,
				TotalCount = tags.Count(),
				Items = tags.Skip(skipCount).Take(search.PerPage).Select(c => new TagDto
				{
					Id = c.Id,
					Name = c.Name
				})
			};
			return tag;



		}
	}
}
