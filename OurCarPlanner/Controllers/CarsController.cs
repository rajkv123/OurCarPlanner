using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OurCarPlanner.Models;
using OurCarPlanner.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using MongoDB.Driver.GridFS;
using System.IO;
using Firebase.Storage;

namespace OurCarPlanner.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarService carService;
        private readonly IHostingEnvironment _iHostEnvironment;
        private string imgurl = "";
        public CarsController(CarService carService, IHostingEnvironment iHostEnvironment)
        {
            this.carService = carService;
            _iHostEnvironment = iHostEnvironment;
        }

        // GET: Cars
        public ActionResult Index()
        {
            return View(carService.Get());
        }

        // GET: Cars/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = carService.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
             
                Stream fs = ReadImageFile(car.ImageUrl);
                car.ImageUrl = StoreImages(fs).Result;


                carService.Create(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = carService.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                Stream fs = ReadImageFile(car.ImageUrl);
                car.ImageUrl = StoreImages(fs).Result;
                carService.Update(id, car);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(car);
            }
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = carService.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var car = carService.Get(id);

                if (car == null)
                {
                    return NotFound();
                }

                carService.Remove(car.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<string> StoreImages(Stream imageStream)
        {
            try
            {
                Random ff = new Random();
                string dd = ff.Next(100, 10000).ToString();
                var stroageImage = await new FirebaseStorage("test-3dead.appspot.com")
                .Child(dd.ToString() + ".jpg")
                .PutAsync(imageStream);
                imgurl = await new FirebaseStorage("test-3dead.appspot.com").Child(dd.ToString() + ".jpg").GetDownloadUrlAsync();


                // await DisplayAlert("done", "uploaded the image", "Ok");

            }
            catch (Exception ex)
            {
            }

            return imgurl;
        }

        public Stream ReadImageFile(string file)
        {
            if (file != null && file.Length != 0)
            {
                var uploadPath = Path.Combine(_iHostEnvironment.WebRootPath, "images");
                FileStream fileStream = new FileStream(Path.Combine(uploadPath,file), FileMode.Open);
                return fileStream;
            }

            return null;
        }
    }
}