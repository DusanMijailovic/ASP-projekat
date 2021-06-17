using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
	public class ArticleConfiguration : IEntityTypeConfiguration<Article>
	{
		public void Configure(EntityTypeBuilder<Article> builder)
		{
			builder.Property(x => x.Headline).IsRequired();
			builder.Property(x => x.Content).IsRequired();
			builder.Property(x => x.DatePosted).IsRequired();

			builder.HasOne(x => x.Categories)
				.WithMany(x => x.Articles)
				.HasForeignKey(x => x.CategoryId)
				.OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(x => x.Photos)
				.WithMany(x => x.Articles)
				.HasForeignKey(x => x.PhotoId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(x=> x.TagArticles)
				.WithOne(x => x.Articles)
				.HasForeignKey(x => x.ArticleId)
				.OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(x => x.Favorites)
				.WithOne(x => x.Articles)
				.HasForeignKey(x => x.ArticleId)
				.OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(x => x.Comments)
				.WithOne(x => x.Articles)
				.HasForeignKey(x => x.ArticleId)
				.OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(x => x.Likes)
				.WithOne(x => x.Articles)
				.HasForeignKey(x => x.ArticleId)
				.OnDelete(DeleteBehavior.Restrict);

		}
	}
}
