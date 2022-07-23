using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ITI.Sauce.MVC.API
{
    //[Authorize]
    public class CartAPIController : ControllerBase
    {
        private readonly CartRepository cartRepository;
        UnitOfWork unitOfWork;

        public CartAPIController(CartRepository _cartRepository, UnitOfWork _unitOfWork
)
        {
            cartRepository = _cartRepository;
            unitOfWork = _unitOfWork;
        }
        [HttpGet]
        public ResultViewModel Get()
        {
            var CartInfo = cartRepository.Get();
            return new ResultViewModel { Data=CartInfo, Success=true};
            
        }
        [HttpGet]
        public ResultViewModel Details(int ID)
        {
            var CartInfo = cartRepository.Get(ID);
            return new ResultViewModel { Data=CartInfo, Success=true};
        }
        [HttpPost]
        public ResultViewModel Add([FromBody] CartEditViewModel model)
        {
            var UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserID= model.UserID ;

            //var claimsIdentity = (System.Security.Claims.ClaimsIdentity)this.User.Identity;
            //var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            //var userId = claim.Value;
            var res = cartRepository.GetList().FirstOrDefault(i => i.Recipe_ID == model.Recipe_ID);
            if (res == null)
            {
                cartRepository.Add(model);
                return new ResultViewModel
                { Data = true, Success = true };
            }
            else
            {
                return new ResultViewModel { Data = false, Success = true };
            }
        }
        [HttpPost]
        public ResultViewModel Remove([FromBody] CartEditViewModel model)
        {
            var result = cartRepository.Remove(model);

            return new ResultViewModel { Data = result, Success = true };
        }
        public ResultViewModel Update([FromBody] CartEditViewModel model)
        {

            var result = cartRepository.Update(model);
            unitOfWork.Save();

            return new ResultViewModel { Data = result, Success = true };
        }
    }
}
