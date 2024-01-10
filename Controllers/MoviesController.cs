using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Data;
using OnlineShop.Data.Base;
using OnlineShop.Data.Enum;
using OnlineShop.Models;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;

namespace OnlineShop.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IdentityDbContext _identityDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public MoviesController(UserManager<ApplicationUser> userManager , AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

      

        public async Task<IActionResult> Index()
        {
            var allMovies = await _context.Movies.Include(n => n.Cinema).OrderBy(n => n.Name).ToListAsync();
          
            return View(allMovies);
        }


        public async Task<List<Producer>> GetAllProducers() => await _context.Producers.ToListAsync();
        public async Task<List<Cinema>> GetAllCinemas() => await _context.Cinemas.ToListAsync();
  
        public static IEnumerable<SelectListItem> GetEnumValues<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum))
                       .Cast<TEnum>()
                       .Select(e => new SelectListItem
                       {
                           Value = e.ToString(),
                           Text = e.ToString()
                       })
                       .ToList();
        }
           
        public async Task<IActionResult> Create()
        {

            List<Cinema> cinemas = await GetAllCinemas();
            List<Producer> producers = await GetAllProducers();
            List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> MovieCategoryList;


            Dictionary<int, string> cinemDropdownValues = new Dictionary<int, string>();
            Dictionary<int, string> prodDropdownValues = new Dictionary<int, string>();

            foreach (var cinema in cinemas)
            {
                cinemDropdownValues.Add(cinema.Id, cinema.Name);
            }

            foreach (var prod in producers)
            {
                prodDropdownValues.Add(prod.Id, prod.FullName);
            }


            ViewBag.DropDownValues = prodDropdownValues;
            ViewBag.CinemaDropDownValues = cinemDropdownValues;

            
            ViewBag.EnumSelectList = GetEnumValues<MovieCategory>();

            return View();

        }

        [HttpPost]
        public IActionResult Create(Movie model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);

            }
            
            _context.Movies.Add(model); 
            _context.SaveChanges(); 
            return RedirectToAction("Index");   
        }

        public async Task<IActionResult> SearchMovies(string movie)
        {
            if(!String.IsNullOrEmpty(movie)) 
            {
                var moviesResult = await _context.Movies.Where(x => x.Name.Contains(movie)).ToListAsync();

                if (moviesResult.Count > 0)
                {
                    return View(moviesResult);
                }
               
              
            }
            return RedirectToAction("Index");
        }


        [Authorize]
        public  IActionResult PressCart()
        {
            List<Movie> movies = new List<Movie>();

            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var items = _context.ShoppingCarts.Where(x => x.UserId == userid);

            var moviesId = new List<int>(); 

            foreach(ShoppingCart item in items)
            {
                moviesId.Add(item.MovieId);
            }

            movies = _context.Movies.Where(b => moviesId.Contains(b.Id)).ToList();

            foreach(Movie item in movies)
            {
                System.Diagnostics.Debug.WriteLine("********&&&&&&*********");

                System.Diagnostics.Debug.WriteLine(item.Name+"|"+item.Id +"|"+item.Price);
                System.Diagnostics.Debug.WriteLine(userid);
                System.Diagnostics.Debug.WriteLine("********&&&&&&*********");
            }

            return View(movies);
        }


        [Authorize]
        [HttpPost]
        public  IActionResult DeleteItemInCard(int id)
        {

            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var item =  _context.ShoppingCarts.FirstOrDefault(x => x.Id == id && x.UserId ==userid );
            if(item is not null)
            {
                try
                {
                    _context.ShoppingCarts.Remove(item);
                    _context.SaveChanges();     
                }
                catch 
                {
                    return View("NotFound");
                }
            }
          
            return View("Index"); 
        }



        
        [Authorize]
        [HttpPost]
        public IActionResult AddItemToCart(int movieId)
        {
           
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            System.Diagnostics.Debug.WriteLine("********&&&&&&*********");
            System.Diagnostics.Debug.WriteLine(movieId.ToString());
            System.Diagnostics.Debug.WriteLine(userid);
            System.Diagnostics.Debug.WriteLine("********&&&&&&*********");


            if (userid != null && movieId > 0)
            {
                _context.ShoppingCarts.Add(new ShoppingCart { UserId = userid, MovieId = movieId });
                _context.SaveChanges();
                TempData["AlertMessage"] = "Movie Added Successfuly";
                return RedirectToAction("Index");
            }

            return View("Index");

        }

        [HttpGet]
        public async Task<IActionResult> OrderByDate()
        {
            var movies = await _context.Movies.Include(n => n.Cinema).OrderBy(n => n.StartDate).ToArrayAsync();

            return View(movies);    
        }


    }
}
