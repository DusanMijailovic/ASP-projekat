using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
	public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
	{
		public void Configure(EntityTypeBuilder<Favorite> builder)
		{
			builder.HasOne(x => x.Users)
				.WithMany(x => x.Favorites)
				.HasForeignKey(x => x.UserId);
			builder.HasOne(x => x.Articles)
				.WithMany(x => x.Favorites)
				.HasForeignKey(x => x.ArticleId);
		}
	}
}
