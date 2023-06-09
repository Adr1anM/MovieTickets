﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using OnlineShop.Data;
using OnlineShop.Data.Services;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
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
        public async Task<IActionResult> Create([Bind("FullName,ProfilePicture,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor); 
            }
            _service.Add(actor);    
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
                return View("Not Found");
            }
            return View(actorDetails);  
        }

        [HttpPost]
        public async Task<IActionResult>Edit(int id,[Bind("Id,FullName,ProfilePicture,Bio")] Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }

           await _service.Update(id, actor);
           return RedirectToAction(nameof(Index)); 

        }

        public async Task<IActionResult> Delete(int id) 
        {
            var actordata  = await _service.GetById(id);  
            if(actordata == null)
            {
                return View("Not fount");
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
                return View("Not Found");
            }
            _service.Delete(tempActor);
            return RedirectToAction(nameof(Index));

            
        }
    }
}
 