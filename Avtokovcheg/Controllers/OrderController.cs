using AvtokovchegApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AvtokovchegApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository, IСontractSpaceRepository сontractSpace)
        {
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {

            return Index();
        }



    }
}
