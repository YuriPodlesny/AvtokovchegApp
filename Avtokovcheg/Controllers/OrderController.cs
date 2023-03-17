using AvtokovchegApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AvtokovchegApp.Controllers
{
    [Authorize]
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
