using AvtokovchegApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AvtokovchegApp.Components
{
    public class ContractCardViewComponent : ViewComponent
    {
        private readonly IСontractSpaceRepository _сontractSpace;

        public ContractCardViewComponent(IСontractSpaceRepository сontractSpace)
        {
            _сontractSpace = сontractSpace;
        }

        public IViewComponentResult Invoke(string userId)
        {
            var result = _сontractSpace.GetContractByUserId(userId);
            return View("ContractCard", result);
        }
    }
}
