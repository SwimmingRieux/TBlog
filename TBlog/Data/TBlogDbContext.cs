using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace TBlog.Data
{
    public class TBlogDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public TBlogDbContext(IConfiguration conf)
        {
            Configuration = conf;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection"));
        }
        public DbSet<Post> Posts {get; set; }
        public DbSet<Tag> Tags {get; set; }
        public DbSet<TagPost> TagPosts {get; set;}
        public DbSet<Category> Categories {get; set;} 
        public DbSet<User> Users { get; set; }
        public DbSet<Site> Sites { get; set; }
    }
}
