using Application.DataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.UseCaseLog
{
	public interface IGetUseCaseLog : IQuery<PagedResponse<UseCaseLogDto>, UseCaseLogSearch >
	{
	}
}
