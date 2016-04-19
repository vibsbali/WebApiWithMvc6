using System.Linq;
using Microsoft.AspNet.Mvc;
using TheWorld.Entities;
using TheWorld.Services;
using TheWorld.ViewModels;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private readonly IMailService mailService;
        private readonly WorldContext context;

        public AppController(IMailService mailService, WorldContext context)
        {
            this.mailService = mailService;
            this.context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var trips = context.Trips.OrderBy(t => t.Name).ToList();
            return View(trips);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {

            if (ModelState.IsValid)
            {
                var email = Startup.Configuration["AppSettings:SiteEmailAddress"];
                if (mailService.SendMail(email, email, $"Contact Page from {model.Name} ({model.Email})", model.Message))
                {
                    ModelState.Clear();
                }
                
                return RedirectToAction("Index", "App");
            }


            return View(model);
        }
    }
}
