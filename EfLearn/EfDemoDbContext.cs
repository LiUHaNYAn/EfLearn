using System;
using Microsoft.EntityFrameworkCore;

namespace EfLearn
{
    public class EfDemoDbContext : DbContext
    {
        public  DbSet<Blog> Blogs { get; set; }
        public  DbQuery<BlogPostCount> BlogPostCounts { get; set; }
        public  DbSet<UserInfo> UserInfos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=localhost;initial catalog=eflearn;uid=sa;pwd=123456",
                builder =>
                {
                    builder.UseRowNumberForPaging(true);
                    
                });
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Blog>().ToTable("tb_blog")
                .Property(p => p.Content).HasColumnType("nvarchar(max)")
                .IsRequired(true).HasColumnName("content");
            builder.Entity<Blog>().Property(p => p.Id).HasColumnName("id");
            builder.Entity<Blog>().Property(p => p.Title).HasMaxLength(50)
                .IsRequired(true).HasColumnName("title");
            builder.Entity<Post>().ToTable("tb_post")
                .Property(p => p.Content).HasColumnType("nvarchar(max)")
                .IsRequired(true).HasColumnName("content");
            builder.Entity<Post>().Property(p => p.Id).HasColumnName("id");
            builder.Entity<Post>().Property(p => p.Title).HasMaxLength(50)
                .IsRequired(true).HasColumnName("title");

            builder.Entity<Blog>()
                .HasData(new Blog() {Id = 4,Content = "seeding data", CreateTime = DateTime.Now, Title = "seeding demo"});
            builder.Query<BlogPostCount>()
                .ToView("view_blogcount")
                .Property(p => p.Title).HasColumnName("title");
            /*序列
            builder.HasSequence<Int64>("orderid", options =>
            {
                options.IncrementsBy(1);
                options.StartsAt(100000);
            });*/
            builder.Entity<UserInfo>(options =>
            {
                options.HasKey(p => p.Id);
                options.Property(p => p.UserName).HasColumnType("nvarchar(50)")
                    .HasColumnName("username")
                    .IsRequired(true);
                /*options.Property(p => p.Token).HasDefaultValueSql("NEXT VALUE FOR orderid");*/
            });
         
        }
    }
}