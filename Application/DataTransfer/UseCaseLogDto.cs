using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
	public class UseCaseLogDto
	{
		public string Actor { get; set; }
		public string Data { get; set; }
		public DateTime Date { get; set; }
		public string UseCaseName
		{
			get; set;

		}
	}
}
