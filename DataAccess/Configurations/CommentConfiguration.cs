using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
	public class CommentConfiguration : IEntityTypeConfiguration<Comment>
	{
		public void Configure(EntityTypeBuilder<Comment> builder)
		{
			builder.HasOne(x => x.Users)
				.WithMany(x => x.Comments)
				.HasForeignKey(x => x.UserId);
			builder.HasOne(x => x.Articles)
				.WithMany(x => x.Comments)
				.HasForeignKey(x => x.ArticleId);
		}
	}
}
