using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SWD_GUI_Assignment.Models;
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
            //Context.Database.Delete();
            return View();
        }

        public ActionResult Sensors()
        {
            //Context.Database.Delete();
            return View();
        }

        // GET: /Manage/Index
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            //Create a serializer
            XmlSerializer serializer = new XmlSerializer(typeof(List<Lokation>));

            // Deserialize all the lokations.
            var temp = (List<Lokation>)serializer.Deserialize(file.InputStream);

            //Add each by their ID. 
            foreach (var newLokation in temp)
            {
                Context.Lokations.AddOrUpdate(newLokation);
            }

            //Save changes
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(RegistrerSensorViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Find the given user to attach his name to the sensor. 
                var userId = User.Identity.GetUserId();
                var user = Context.Users.Where(x => x.Id == userId).FirstOrDefault();

                var randomSensorId = GetRandomHexNumber(16);
                //Ensure that this random ID does not already exists. 
                while (Context.Sensors.Any(x => x.Sensorid == randomSensorId))
                {
                    randomSensorId = GetRandomHexNumber(16);
                }

                //Create sensor
                var sensor = new Sensor()
                {
                    CreatedBy = user.Navn,
                    Lat = model.Lat,
                    Lon = model.Lon,
                    LokationsId = model.LokationsId,
                    Træart = model.Træart,
                    Sensorid = model.SensorId
                };

                //Add to database
                Context.Sensors.Add(sensor);
                Context.SaveChanges();
                //Return with blank form
                return RedirectToAction("Index", "Home");
            }

            // Something failed - Return with model. 
            return View(model);
        }


        /// <summary>
        /// Taken from: https://stackoverflow.com/questions/1054076/randomly-generated-hexadecimal-number-in-c-sharp
        /// </summary>
        static Random random = new Random();
        public static string GetRandomHexNumber(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }

    }
}