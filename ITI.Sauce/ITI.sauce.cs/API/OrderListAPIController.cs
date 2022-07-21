using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ITI.Sauce.MVC.API
{
    public class OrderListAPIController : ControllerBase
    {
        private readonly OrderListRepository orderListRepository;
        public OrderListAPIController(OrderListRepository _orderListRepository)
        {
            orderListRepository = _orderListRepository;
        }
        [HttpGet]
        public ResultViewModel Get()
        {
            var OrderListInfo = orderListRepository.Get();
            return new ResultViewModel { Data = OrderListInfo, Success = true };

        }

        [HttpPost]
        public ResultViewModel Add([FromBody] OrderListEditViewModel model)
        {
            var result = orderListRepository.Add(model);
            return new ResultViewModel { Data = result, Success = true };
        }
    }
}
