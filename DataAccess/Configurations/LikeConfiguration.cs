using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
	public class LikeConfiguration : IEntityTypeConfiguration<Like>
	{
		public void Configure(EntityTypeBuilder<Like> builder)
		{
			builder.HasOne(x => x.Users)
				.WithMany(x => x.Likes)
				.HasForeignKey(x => x.UserId);
			builder.HasOne(x => x.Articles)
				.WithMany(x => x.Likes)
				.HasForeignKey(x => x.ArticleId);
		}
	}
}
