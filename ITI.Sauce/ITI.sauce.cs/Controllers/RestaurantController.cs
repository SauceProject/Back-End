﻿using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace ITI.sauce.MVC.Controllers
{
    public class RestaurantController : Controller
    {

        private readonly RestaurantRepository ResRepo;
        private readonly UnitOfWork UnitOfWork;
        public RestaurantController(RestaurantRepository _RepoRes, UnitOfWork _unitOfWork)
        {
            DBContext dBContext = new DBContext();
            this.ResRepo = _RepoRes;
            UnitOfWork = _unitOfWork;
        }
        [Authorize(Roles = "Admin,User,Vendor")]
        public IActionResult Get(int vendorID = 0,int id = 0, DateTime? WorkTime = null, string NameEn = "", string NameAr = "", DateTime? registerDate = null, bool isDeleted = false, string orderby = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20)
        {
            var Resultdata =
                ResRepo .Get (vendorID,id, WorkTime, NameEn, NameAr, registerDate, isDeleted, orderby, isAscending, pageIndex, pageSize);
            return View(Resultdata);
        }
        [Authorize(Roles = "Admin,Vendor")]
        public IActionResult Search(int pageIndex = 1, int pageSize = 2)
        {
            var Data = ResRepo.Search(pageIndex, pageSize);
            return View("Get", Data);
        }
        [Authorize(Roles = "Admin,Vendor")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Vendor")]
        [HttpPost]
        public IActionResult Add(RestaurantEditViewModel model)
        {
            string? bookUploadUrl = "/Content/Uploads/Resturant/";

            string newFileName = Guid.NewGuid().ToString() + model.Image.FileName;
            model.ImageUrl = bookUploadUrl + newFileName;

            FileStream fs = new FileStream(Path.Combine
                (
                    Directory.GetCurrentDirectory(),
                    "Content",
                   "Uploads", "Resturant", newFileName
                ), FileMode.Create);

            model.Image.CopyTo(fs);
            fs.Position = 0;

            ResRepo.Add(model);
            UnitOfWork.Save();
            return RedirectToAction("Get");
        }
    }
}
