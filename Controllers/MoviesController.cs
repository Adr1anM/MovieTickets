using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Data;
using OnlineShop.Data.Base;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;


        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await _context.Movies.Include(n => n.Cinema).OrderBy(n => n.Name).ToListAsync();
            return View(allMovies);
        }




    }
}
