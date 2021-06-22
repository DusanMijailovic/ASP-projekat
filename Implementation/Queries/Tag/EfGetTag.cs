using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.Tag;
using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Queries.Tag
{
	public class EfGetTag : IGetTag
	{
		private readonly SportskeContext _context;
		private readonly IMapper _mapper;

		public EfGetTag(SportskeContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public int Id => 13;

		public string Name => "Get tag";

		public TagDto Execute(int search)
		{
			var tag = _context.Tags.Find(search);

			if (tag == null)
			{
				throw new EntityNotFoundException(search, typeof(Domain.Entities.Tag));
			}

			return _mapper.Map<TagDto>(tag);


		}
	}
}
