using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TBlog.Data;

namespace TBlog
{
    public class PostModel : PageModel
    {
        private readonly TBlogDbContext _context;
        public PostModel(TBlogDbContext context)
        {
            _context = context;
        }
        public IList<Post> Data { get; set; }
        public IList<Site> SiteData { get; set; }
        public IList<User> UserData { get; set; }
        public IList<Tag> TagsData { get; set; }
        public IList<TagPost> TagPostsData { get; set; }
        public IList<Category> CatsData { get; set; }
        public int artcleId { get; set; }
        public async Task<ActionResult> OnGetAsync()
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(Request.QueryString.ToString());
            int id = int.Parse(queryString["id"]);
            artcleId = id;
            Data = await _context.Posts.OrderByDescending(itm => itm.PViews).ToListAsync();
            SiteData = await _context.Sites.ToListAsync();
            UserData = await _context.Users.ToListAsync();
            TagsData = await _context.Tags.ToListAsync();
            TagPostsData = await _context.TagPosts.Where(tp => tp.PId == id).ToListAsync();
            CatsData = await _context.Categories.ToListAsync();
            var post = Data.SingleOrDefault(p => p.PId == id);
            if(post==null) return Redirect("/Error");
            return null;
        }
    }
}