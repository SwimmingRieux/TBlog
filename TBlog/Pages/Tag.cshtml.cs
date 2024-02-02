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
    public class TagModel : PageModel
    {
        private readonly TBlogDbContext _context;

        public TagModel(TBlogDbContext context)
        {
            _context = context;
        }

        public IList<Post> Data { get; set; }
        public IList<Site> SitesData { get; set; }
        public IList<User> UsersData { get; set; }
        public IList<Category> CatsData { get; set; }
        public IList<Tag> TagsData { get; set; }
        public IList<TagPost> TagPostsData { get; set; }
        public IList<Post> PostsData { get; set; }
        public Tag modelTag { get; set; }
        public int tid { get; set; }
        public int order_by { get; set; }
        public async Task<ActionResult> OnGetAsync()
        {
            order_by = 0;
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(Request.QueryString.ToString());
            tid = int.Parse(queryString["id"]);
            
            TagPostsData = await _context.TagPosts.ToListAsync();
            PostsData = await _context.Posts.OrderByDescending(itm => itm.PId).ToListAsync();
            if (queryString.AllKeys.Contains("order_by"))
            {
                if (queryString["order_by"] == "views")
                {
                    order_by = 1;
                    PostsData = PostsData.OrderByDescending(itm => itm.PViews).ToList();
                }
            }
            Data = new List<Post>();
            foreach(var itm in TagPostsData)
            {
                if(itm.TId == tid)
                {
                    Data.Add(PostsData.SingleOrDefault(p => p.PId == itm.PId));
                }
            }
            SitesData = await _context.Sites.ToListAsync();
            UsersData = await _context.Users.ToListAsync();
            CatsData = await _context.Categories.ToListAsync();
            TagsData = await _context.Tags.ToListAsync();
            modelTag = TagsData.SingleOrDefault(t => t.TId == tid);
            return null;
        }
    }
}