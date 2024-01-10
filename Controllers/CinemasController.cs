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
        [HttpPost]
        public async Task<JsonResult> CreateWithModal(Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    status = "failure",
                    formErrors = ModelState.Select(kvp => new { key = kvp.Key, errors = kvp.Value?.Errors.Select(e => e.ErrorMessage) })
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
                return Json( new
                {
                    status = "failure",
                    formErrors = ModelState.Select(kvp => new { key = kvp.Key, errors = kvp.Value?.Errors.Select(e => e.ErrorMessage) })
                });
            }

            return Json(cinemaDetails);     

        }

        [Authorize]
        [HttpPost]  
        public async Task<IActionResult> Update(Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    status = "failure",
                    formErrors = ModelState.Select(kvp => new { key = kvp.Key, errors = kvp.Value?.Errors.Select(e => e.ErrorMessage) })    
                });
            }

            await _service.Update(cinema);
            return Json("Product Details Updated");
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaData = await _service.GetById(id);
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    status = "failure",
                });
            }

            return Json(cinemaData); 

        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Cinema tempCinema)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { status = "failure" });
            }
            await _service.Delete(tempCinema);
            return Json("Product Details Deleted");


        }   
    }
}
