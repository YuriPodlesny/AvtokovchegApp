using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace AvtokovchegApp.Components
{
    public class GetRequestViewComponent : ViewComponent
    {
        private readonly IRequestRepository _requestRepository;

        public GetRequestViewComponent(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public  IViewComponentResult Invoke()
        {
            var result = _requestRepository.GetRequestByState(0);
            return View("GetRequest", result);
        }
    }
}
