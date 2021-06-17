using Application;
using DataAccess;
using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Logging
{
	public class DatabaseUseCaseLogger : IUseCaseLogger
	{

		private readonly SportskeContext _context;

		public DatabaseUseCaseLogger(SportskeContext context)
		{
			_context = context;
		}

		public void Log(IUseCase userCase, IApplicationActor actor, object data)
		{

			_context.UseCaseLogs.Add(new UseCaseLog
			{
				Date = DateTime.Now,
				Actor = actor.Identity,
				Data = JsonConvert.SerializeObject(data),
				UseCaseName = userCase.Name.ToString()


			});

		}
	}
}
