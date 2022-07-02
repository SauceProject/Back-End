using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ITI.sauce.MVC.Controllers
{
    public class RatingController : Controller
    {
        private readonly UnitOfWork UnitOfWork;
        private readonly RatingRepository RatepRepo;


        public RatingController( UnitOfWork _unitOfWork
            , RatingRepository _RatepRepo)
        {
            DBContext dBContext = new DBContext();
            UnitOfWork = _unitOfWork;
            RatepRepo = _RatepRepo;
        }
        public IActionResult Get(int id = 0, int RatingValue = 0,
                string orderyBy = "", bool isAscending = false,
                int pageIndex = 1, int pageSize = 20)
        {
            var data =
            RatepRepo.Get(id, RatingValue,orderyBy,
                isAscending, pageIndex, pageSize);
            return View(data);
        }
        public IActionResult GetById(int id)
        {
            var data =
           RatepRepo.Get(id);
            return View(data);
        }
        public IActionResult Search(int pageIndex = 1, int pageSize = 2)
        {
            var Data = RatepRepo.Search(pageIndex, pageSize);
            return View("Get", Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<TextValueViewModel> Values = RatepRepo.GetRecipeID();
            ViewBag.Rating = Values;
            return View();
        }
        [HttpPost]
        public IActionResult Add(RatingEditViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                RatepRepo.Add(model);
                UnitOfWork.Save();
                return RedirectToAction("Search");
            }
            else
                return View();
        }






        [HttpGet]
        public IActionResult Update(int Id)
        {
            var Results = RatepRepo.GetOne(Id);

            return View(Results.ToEditViewModel());

        }






        [HttpPost]
        public IActionResult Update(RatingEditViewModel model, int ID = 0)
        {
            RatepRepo.Update(model);
            UnitOfWork.Save();
            return RedirectToAction("Get");

        }









    }
}
