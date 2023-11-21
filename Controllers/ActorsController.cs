using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using OnlineShop.Data;
using OnlineShop.Data.Base;
using OnlineShop.Data.Services;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IGenericRepository<Actor> _service;

        public ActorsController(IGenericRepository<Actor> service)
        {
            _service = service;

        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Create([Bind("FullName,ProfilePicture,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor); 
            }
            await _service.Add(actor);    
            return RedirectToAction(nameof(Index));   
        }

        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetById(id);
            if (actorDetails == null) 
            {
                return View("Empty"); 
            }
                
            return View(actorDetails);  
        }

        public async Task<IActionResult> Edit(int id)
        {

            var actorDetails = await _service.GetById(id);
            if(actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);  
        }

        [HttpPost]
        public async Task<IActionResult>Edit(Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }

           await _service.Update(actor);
           return RedirectToAction(nameof(Index)); 

        }

        public async Task<IActionResult> Delete(int id) 
        {
            var actordata  = await _service.GetById(id);  
            if(actordata == null)
            {
                return View("NotFount");
            }
            return View(actordata);

        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var tempActor = await _service.GetById(id);
            if (tempActor == null)
            {
                return View("NotFound");
            }
            await _service.Delete(tempActor);
            return RedirectToAction(nameof(Index));

            
        }
    }
}
 