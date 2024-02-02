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
    public class UserModel : PageModel
    {
        private readonly TBlogDbContext _context;

        public UserModel(TBlogDbContext context)
        {
            _context = context;
        }

        public IList<Post> Data { get; set; }
        public IList<Site> SitesData { get; set; }
        public IList<User> UsersData { get; set; }
        public IList<Category> CatsData { get; set; }
        public User modelUsr { get; set; }
        public int uid { get; set; }
        public int order_by { get; set; }
        public async Task<ActionResult> OnGetAsync()
        {
            order_by = 0;
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(Request.QueryString.ToString());
            uid = int.Parse(queryString["id"]);
            Data = await _context.Posts.Where(p => p.PUId == uid).OrderByDescending(itm => itm.PId).ToListAsync();
            if (queryString.AllKeys.Contains("order_by"))
            {
                if (queryString["order_by"] == "views")
                {
                    order_by = 1;
                    Data = Data.OrderByDescending(itm => itm.PViews).ToList();
                }
            }
            SitesData = await _context.Sites.ToListAsync();
            UsersData = await _context.Users.ToListAsync();
            CatsData = await _context.Categories.ToListAsync();
            modelUsr = UsersData.SingleOrDefault(u => u.UId == uid);
            return null;
        }
    }
}