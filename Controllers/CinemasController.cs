using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Data.Base;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class CinemasController : Controller
    {
        private readonly IGenericRepository<Cinema> _service;

        public CinemasController(IGenericRepository<Cinema> service)
        {

            _service = service; 
        } 
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAll();
            return View(result);    
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Name,Logo,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            _service.Add(cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {

            var cinemaDetails = await _service.GetById(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }

            return View(cinemaDetails);

            

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Logo,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _service.Update(id, cinema);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            var cinemaData = await _service.GetById(id);
            if (cinemaData == null)
            {
                return View("NotFount");
            }
            return View(cinemaData);

        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var tempCinema = await _service.GetById(id);
            if (tempCinema == null)
            {
                return View("NotFound");
            }
            _service.Delete(tempCinema);
            return RedirectToAction(nameof(Index));


        }
    }
}
