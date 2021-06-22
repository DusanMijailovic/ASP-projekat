using Application.DataTransfer;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
	public class CategoryProfile : Profile
	{
		public CategoryProfile()
		{

			CreateMap<Category, CategoryDto>();
			CreateMap<CategoryDto, Category>();
		}
	}
}
