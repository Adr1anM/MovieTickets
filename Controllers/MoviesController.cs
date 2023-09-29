using Microsoft.AspNetCore.Identity;
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


        public List<Producer> GetAllProducers() => _context.Producers.ToList();
        public List<Cinema> GetAllCinemas() => _context.Cinemas.ToList();
        //public IActionResult Create(Movie model, int id)
        //{
        //    List<Producer> producers = GetAllProducers();
        //    List<Cinema> cinemas = GetAllCinemas();

        //    model.ProducerId = id;  
        //    _context.Movies.Add(model); 

        //    if (producers.Count > 0)
        //    {

        //    ViewBag.DropdownItems = new SelectList(producers);


        //    return View();
        //    }

        //    return RedirectToAction("Index");
        //}
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


        public IActionResult Create()
        {

            List<Cinema> cinemas = GetAllCinemas();
            List<Producer> producers = GetAllProducers();
            List<SelectListItem> MovieCategoryList;


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

            IEnumerable<SelectListItem> enumValues = GetEnumValues<MovieCategory>();
            ViewBag.EnumSelectList = enumValues;

            return View();

        }

        [HttpPost]
        public IActionResult Create(Movie model)
        {
            System.Diagnostics.Debug.WriteLine("$$$$*****$$$$$$$$$$$$$$$$");
            System.Diagnostics.Debug.WriteLine(model.Name +"  "+model.CinemaId);
            System.Diagnostics.Debug.WriteLine(model.Description + "  " + model.ProducerId);
            System.Diagnostics.Debug.WriteLine(model.StartDate);
            System.Diagnostics.Debug.WriteLine(model.EndDate);
            System.Diagnostics.Debug.WriteLine(model.MovieCategory);
            System.Diagnostics.Debug.WriteLine(model.ImageUrl);
            System.Diagnostics.Debug.WriteLine("$$$$*****$$$$$$$$$$$$$$$$");

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
     

        //[HttpPost]
        //public async Task<IActionResult> Create(int id)
        //{


        //}




    }
}
