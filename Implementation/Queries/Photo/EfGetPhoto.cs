using Application.DataTransfer;
using Application.Queries;
using Application.Queries.Photo;
using Application.Searches;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Photo
{
	public class EfGetPhoto : IGetPhoto
	{
		private readonly SportskeContext _context;

		public EfGetPhoto(SportskeContext context)
		{
			_context = context;
		}

		public int Id => 32;

		public string Name => "Get photo";

		public PagedResponse<GetPhotoDto> Execute(PhotoSearch search)
		{
			var photos = _context.Photos.AsQueryable();
			if (!string.IsNullOrEmpty(search.Src) || !string.IsNullOrWhiteSpace(search.Src))
			{
				photos = photos.Where(x => x.Src.ToLower().Contains(search.Src.ToLower()));
			}

			var skipCount = search.PerPage * (search.Page - 1);
			var photo = new PagedResponse<GetPhotoDto>
			{
				CurrentPage = search.Page,
				ItemsPerPage = search.PerPage,
				TotalCount = photos.Count(),
				Items = photos.Skip(skipCount).Take(search.PerPage).Select(c => new GetPhotoDto
				{
					Id = c.Id,
					Src = c.Src
				}).ToList()
			};
			return photo;

		}
	}
}
