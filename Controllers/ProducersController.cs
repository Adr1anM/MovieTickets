using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Data.Base;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IGenericRepository<Producer> _service;

        public ProducersController(IGenericRepository<Producer> service)
        {
            _service = service;
        }

        public async  Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAll();
            return View(allProducers);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePicture,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.Add(producer);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetById(id);
            if (producerDetails == null)
            {
                return View("Empty");
            }

            return View(producerDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {

            var producerDetails = await _service.GetById(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePicture,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _service.Update(id, producer);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            var producerData = await _service.GetById(id);
            if (producerData == null)
            {
                return View("NotFount");
            }
            return View(producerData);

        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var tempProducer = await _service.GetById(id);
            if (tempProducer == null)
            {
                return View("NotFound");
            }
            _service.Delete(tempProducer);
            return RedirectToAction(nameof(Index));


        }
    }
}
