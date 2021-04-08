using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;

namespace WaterProject.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private ICharityRepository repository;

        public NavigationMenuViewComponent (ICharityRepository r)
        {
            repository = r;
        }
        public IViewComponentResult Invoke()
        {
            //going to the values in the route data and getting the category
            ViewBag.SelectedType = RouteData?.Values["category"];

            return View(repository.Projects
                .Select(x => x.Type)
                .Distinct()
                //order by whatever is normal for that data
                .OrderBy(x => x));
        }
    }
}
