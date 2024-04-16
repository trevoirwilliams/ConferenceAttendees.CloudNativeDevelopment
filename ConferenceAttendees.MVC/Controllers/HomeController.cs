using ConferenceAttendees.MVC.Models;
using ConferenceAttendees.MVC.Services.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace ConferenceAttendees.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClient _client;

        public HomeController(ILogger<HomeController> logger, IClient client)
        {
            _logger = logger;
            this._client = client;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Genders"] = new SelectList( await _client.GendersAllAsync(), "Id", "Name");
            ViewData["JobRoles"] = new SelectList(await _client.JobRolesAllAsync(), "Id", "Name");
            ViewData["RefSources"] = new SelectList(await _client.ReferralSourcesAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Attendee attendee)
        {
            await _client.AttendeesPOSTAsync(attendee);
            return RedirectToAction(nameof(Confirmation));
        }

        public IActionResult Confirmation()
        {
            return View();
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
