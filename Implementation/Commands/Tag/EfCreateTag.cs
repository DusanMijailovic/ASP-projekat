using Application.Commands.Tag;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using FluentValidation;
using Implementation.Validators.Tag;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Tag
{
	public class EfCreateTag : ICreateTag
	{
		private readonly SportskeContext _context;
		private readonly CreateTagValidator _validator;
		private readonly IMapper _mapper;
		public EfCreateTag(SportskeContext context, CreateTagValidator validator, IMapper mapper)
		{
			_context = context;
			_validator = validator;
			_mapper = mapper;
		}

		public int Id => 14;

		public string Name => "Create tag";

		public void Execute(TagDto request)
		{
			_validator.ValidateAndThrow(request);
			_context.Tags.Add(_mapper.Map<Domain.Entities.Tag>(request));
			_context.SaveChanges();

		}
	}
}
