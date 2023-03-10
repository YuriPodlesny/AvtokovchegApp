using AvtokovchegApp.Infrastructure.Business;
using AvtokovchegApp.Models;
using AvtokovchegApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AvtokovchegApp.Controllers
{
    public class ParkingSpaceController : Controller
    {
        IParkingSpaceRepository _parkingSpace;

        public ParkingSpaceController(IParkingSpaceRepository parkingSpace)
        {
            _parkingSpace = parkingSpace;
        }

        public IActionResult Index(SortState sortOrder = SortState.NamberAsc)
        {
            var parkingSpace = _parkingSpace.GetAll();

            ViewBag.NamberSort = sortOrder == SortState.NamberAsc ? SortState.NamberDesc : SortState.NamberAsc;
            ViewBag.FloorSort = sortOrder == SortState.FloorAsc ? SortState.FloorDesc : SortState.FloorAsc;
            ViewBag.IsFreeSort = sortOrder == SortState.IsFreeAsc ? SortState.IsFreeDesc : SortState.IsFreeAsc;

            parkingSpace = sortOrder switch
            {
                SortState.NamberDesc => parkingSpace.OrderByDescending(s => s.Namber),
                SortState.IsFreeAsc => parkingSpace.OrderBy(s => s.IsFree),
                SortState.IsFreeDesc => parkingSpace.OrderByDescending(s => s.IsFree),
                SortState.FloorAsc => parkingSpace.OrderBy(s => s.Floor),
                SortState.FloorDesc => parkingSpace.OrderByDescending(s => s.Floor),
                _ => parkingSpace.OrderBy(s => s.Namber)
            };
            return View(parkingSpace);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeStatus(int spaceId)
        {
            var space = await _parkingSpace.Get(spaceId);
            if (space == null)
            {
                return NotFound();
            }
            var model = new ChangeStatusParkingSpaceViewModel
            {
                Namber = space.Namber,
                IsFree = space.IsFree,
            };
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> ChangeStatus(ChangeStatusParkingSpaceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var space = await _parkingSpace.Get(model.Namber);
                if (space != null)
                {
                    space.Namber = model.Namber;
                    space.IsFree = model.IsFree;


                    var result = await _parkingSpace.Update(space);
                    if (result == true)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return NotFound();
            }
            return View(model);
        }
    }
}
