using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hasici.Web
{

    /// <summary>
    ///The class that gets the last articles from the database
    /// </summary>
    public class RecentlyAddedArticles : ViewComponent
    {

        private readonly ApplicationDbContext _context;


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context"></param>
        public RecentlyAddedArticles(ApplicationDbContext context)
        {
            _context = context;
        }
        
        
        public async Task<IViewComponentResult> InvokeAsync(int numberOfArticles)
        {
           

            var articles = await GetArticles(numberOfArticles);

            ViewData["Title_2"] = "Články";
            return View(articles);
        }


        /// <summary>
        /// Gets the given number of Articles from database 
        /// </summary>
        /// <param name="numberOfArticles">number of articles</param>
        /// <returns></returns>
        private Task<List<Article>> GetArticles(int numberOfArticles)
        {
            return _context.Articles
                .AsNoTracking()
                    .Where(p => p.Publised == true)
                        .OrderByDescending(d => d.Date)
                            .Skip(1)
                                .Take(numberOfArticles)
                                    .ToListAsync();
            
        }

    }
}
