using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Data;
using OnlineShop.Data.Base;
using OnlineShop.Models;
using OnlineShop.Models.Combined;

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
            Cinema cinema = new Cinema();
            IEnumerable<Cinema> cinemaList = await _service.GetAll();

            CinemaViewModel viewModel = new CinemaViewModel
            {
                Cinema = cinema,
                Cinemas = cinemaList
            };

            return View(viewModel);    
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreateWithModal(Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    status = "failure",
                    formErrors = ModelState.Select(kvp => new { key = kvp.Key, errors = kvp.Value.Errors.Select(e => e.ErrorMessage) })
                });
            }

       
            await _service.Add(cinema);
            return Json("Product Details Saved");
            


        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {

            var cinemaDetails = await _service.GetById(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }

            return View(cinemaDetails);

            

        }

        [Authorize]
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

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaData = await _service.GetById(id);
            if (cinemaData == null)
            {
                return View("NotFount");
            }
            return View(cinemaData);

        }

        [Authorize]
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
