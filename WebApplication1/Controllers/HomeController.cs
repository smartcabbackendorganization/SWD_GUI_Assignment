using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public ApplicationDbContext Context
        {
            get
            {
                return _context ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            }
            private set
            {
                _context = value;
            }
        }

        public ActionResult Index()
        {
            return View();
        }


        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(RegistrerVarroeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var varroe = new Varomides()
                {
                    Comments = model.Comments,
                    Count = model.Count,
                    DaysObserved = model.DaysObserved,
                    Navn = model.Navn
                };

                Context.Varroemides.Add(varroe);
                Context.SaveChanges();
                //Return with blank form
                return View(new RegistrerVarroeViewModel());
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

    }
}