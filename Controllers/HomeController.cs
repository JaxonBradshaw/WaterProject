using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;
using WaterProject.Models.ViewModels;

namespace WaterProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ICharityRepository _repository;

        public int PageSize = 2;

        public HomeController(ILogger<HomeController> logger, ICharityRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int pageNum = 1)
        {
            return View(new ProjectListViewModel
            {

                Projects = _repository.Projects
                //queries written in Linq
                //setting up filter for category
                    .Where(p => category == null || p.Type == category)   
                //setting up page filter
                    .OrderBy(p => p.ProjectId)
                    .Skip((pageNum - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    //fixing it so that it displays the correct number of pages
                    TotalNumItems = category == null ? _repository.Projects.Count() :
                        _repository.Projects.Where(x => x.Type == category).Count()
                },
                Type = category
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
