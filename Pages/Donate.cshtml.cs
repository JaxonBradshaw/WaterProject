using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterProject.Infrastructure;
using WaterProject.Models;

namespace WaterProject.Pages
{
    public class DonateModel : PageModel
    {
        private ICharityRepository repository;

        //Constructor
        public DonateModel (ICharityRepository repo)
        {
            repository = repo;
        }

        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //Methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long projectId, string returnUrl)
        {
            Project project = repository.Projects.FirstOrDefault(p => p.ProjectId == projectId);

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(project, 1);

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
