using Application.DataTransfer;
using Application.Queries;
using Application.Queries.UseCaseLog;
using Application.Searches;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.UseCaseLog
{
	public class EfGetUseCaseLog : IGetUseCaseLog
	{
		private readonly SportskeContext _context;

		public EfGetUseCaseLog(SportskeContext context)
		{
			_context = context;
		}

		public int Id => 34;

		public string Name => "Get usecase log";

		public PagedResponse<UseCaseLogDto> Execute(UseCaseLogSearch search)
		{
			var use = _context.UseCaseLogs.AsQueryable();
			if (!string.IsNullOrEmpty(search.UserName) || !string.IsNullOrWhiteSpace(search.UserName))
			{
				use = use.Where(x => x.Actor.ToLower().Contains(search.UserName.ToLower()));
			}
			if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
			{
				use = use.Where(x => x.UseCaseName.ToLower().Contains(search.Name.ToLower()));
			}
			if (search.DateFrom != null && search.DateFrom >= search.DateTo)
			{
				use = use.Where(x => x.Date >= search.DateFrom);
			}
			if (search.DateTo != null && search.DateTo > search.DateFrom)
			{
				use = use.Where(x => x.Date <= search.DateTo);
			}
			var skipCount = search.PerPage * (search.Page - 1);
			var us = new PagedResponse<UseCaseLogDto>
			{
				CurrentPage = search.Page,
				ItemsPerPage = search.PerPage,
				TotalCount = use.Count(),
				Items = use.Skip(skipCount).Take(search.PerPage).Select(c => new UseCaseLogDto
				{
					Actor = c.Actor,
					Data = c.Data,
					Date = c.Date,
					UseCaseName = c.UseCaseName
				}).ToList()

			};
			return us;
		}
	}
}
