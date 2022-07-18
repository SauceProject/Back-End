using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI.sauce.MVC.Controllers
{
    public class RatingController : Controller
    {
        private readonly UnitOfWork UnitOfWork;
        private readonly RatingRepository RatepRepo;
        private readonly UserRepository UserRepo;



        public RatingController( UnitOfWork _unitOfWork
            , RatingRepository _RatepRepo, UserRepository _UserRepo)
        {
            UnitOfWork = _unitOfWork;
            RatepRepo = _RatepRepo;
            UserRepo = _UserRepo;
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
            IEnumerable<SelectListItem> Ratings =
                GetRatingNames(RatepRepo.GetRecipeID());
            ViewBag.Rating = Ratings;

           
            return View();
        }

        private IEnumerable<SelectListItem> GetRatingNames(List<TextValueViewModel> list)
        {
            return list.Select(i => new SelectListItem
            {
                Text = i.Text,
                Value = i.Value.ToString()
            });
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
