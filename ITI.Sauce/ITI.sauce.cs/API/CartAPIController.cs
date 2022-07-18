using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI.Sauce.MVC.API
{
    //[Authorize]
    public class CartAPIController : ControllerBase
    {
        private readonly CartRepository cartRepository;
        public CartAPIController(CartRepository _cartRepository)
        {
            cartRepository = _cartRepository;
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
            var result = cartRepository.Add(model);
            return new ResultViewModel { Data = result, Success = true };
        }
        [HttpPost]
        public ResultViewModel Remove([FromBody] CartEditViewModel model)
        {
            var result = cartRepository.Remove(model);

            return new ResultViewModel { Data = result, Success = true };
        }
    }
}
