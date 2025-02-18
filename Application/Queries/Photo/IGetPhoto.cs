﻿using Application.DataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Photo
{
	public interface IGetPhoto : IQuery<PagedResponse<GetPhotoDto>, PhotoSearch >
	{
	}
}
