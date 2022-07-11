using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ITI.sauce.MVC.Controllers
{
    public class RatingAPIController : ControllerBase
    {
        private readonly UnitOfWork UnitOfWork;
        private readonly RatingRepository RatepRepo;


        public RatingAPIController(UnitOfWork _unitOfWork
            , RatingRepository _RatepRepo)
        {
            //DBContext dBContext = new DBContext();
            UnitOfWork = _unitOfWork;
            RatepRepo = _RatepRepo;
        }
        public IActionResult Get(int id = 0, int RatingValue = 0,
                string orderyBy = "", bool isAscending = false,
                int pageIndex = 1, int pageSize = 20)
        {
            var data =
            RatepRepo.Get(id, RatingValue, orderyBy,
                isAscending, pageIndex, pageSize);
            return null;
        }
        public IActionResult GetById(int id)
        {
            var data =
           RatepRepo.Get(id);
            return null;
        }
        public IActionResult Search(int pageIndex = 1, int pageSize = 2)
        {
            var Data = RatepRepo.Search(pageIndex, pageSize);
            return new ObjectResult(Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<TextValueViewModel> Values = RatepRepo.GetRecipeID();
            return null;
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
                return null;
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            var Results = RatepRepo.GetOne(Id);

            return null;

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
