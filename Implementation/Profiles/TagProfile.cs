using Application.DataTransfer;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
	public class TagProfile : Profile
	{
		public TagProfile()
		{
			CreateMap<Tag, TagDto>();
			CreateMap<TagDto, Tag>();

		}
	}
}
