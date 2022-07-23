using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using ITI.Sauce.Repository;



namespace ITI.sauce.MVC.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IngredientRepository IngrRepo;
        private readonly UnitOfWork UnitOfWork;

        public IngredientController(IngredientRepository _ingrRepo, UnitOfWork _unitOfWork)
        {
            IngrRepo = _ingrRepo;
            UnitOfWork = _unitOfWork;
        }

        public IActionResult Get(int ID = 0, string orderBy = null, bool isAscending = false, string NameEN = "",
            string NameAR = "", string ImageUrl = "", int pageIndex = 1, int pageSize = 20)
        {
            var data =
                IngrRepo.Get(ID, orderBy, isAscending, NameEN, NameAR, ImageUrl, pageIndex, pageSize);

            return View(data);
        }
        public IActionResult Search(int pageIndex = 1, int pageSize = 4)
        {
            var Data = IngrRepo.Search(pageIndex, pageSize);
            return View("Get", Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IngredientEditViewModel model)
        {
            string? bookUploadUrl = "/Content/Uploads/Ingredient/";

            string newFileName = Guid.NewGuid().ToString() + model.Image.FileName   ;
            model.ImageUrl = bookUploadUrl + newFileName;

            FileStream fs = new FileStream(Path.Combine
                (
                    Directory.GetCurrentDirectory(),
                    "Content",
                   "Uploads", "Ingredient", newFileName
                ), FileMode.Create);

            model.Image.CopyTo(fs);
            fs.Position = 0;

            IngrRepo.Add(model);
            UnitOfWork.Save();
            return RedirectToAction("Get");
            
        }





        [HttpGet]
        public IActionResult Update(int Id)
        {
            var Results = IngrRepo.GetOne(Id);
            //ViewBag.Id = res.CatID;

            return View(Results.ToEditViewModel());

        }






        [HttpPost]
        public IActionResult Update(IngredientEditViewModel model, int ID = 0)
        {
            //get from data
            string? bookUploadUrl = "/Content/Uploads/Ingredient/";

            string newFileName = Guid.NewGuid().ToString() + model.Image.FileName;
            model.ImageUrl = bookUploadUrl + newFileName;

            FileStream fs = new FileStream(Path.Combine
                (
                    Directory.GetCurrentDirectory(),
                    "Content",
                   "Uploads", "Ingredient", newFileName
                ), FileMode.Create);

            model.Image.CopyTo(fs);
            fs.Position = 0;
            IngrRepo.Update(model);
            UnitOfWork.Save();
            return RedirectToAction("Get");

        }







        [HttpGet]
        public IActionResult Remove(IngredientEditViewModel model, int ID)
        {
            var res = IngrRepo.Remove(model);
            UnitOfWork.Save();
            return RedirectToAction("Get");


        }

    }
}


