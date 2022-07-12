using ITI.Sauce.Repository;
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
        public ObjectResult Get()
        {
            var CartInfo = cartRepository.Get();
            return new ObjectResult(CartInfo);
            
        }
        public ObjectResult Details(int ID)
        {
            var CartInfo = cartRepository.Get(ID);
            return new ObjectResult(CartInfo);
        }
    }
}
