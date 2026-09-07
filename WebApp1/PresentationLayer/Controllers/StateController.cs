using Microsoft.AspNetCore.Mvc;

namespace WebApp1.PresentationLayer.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index()
        {
            // Read cookie sent from the browser.
            ViewBag.CookieUserName =
                HttpContext.Request.Cookies["UserName"];

            // Read value stored on server for this user.
            ViewBag.SessionUserId =
                HttpContext.Session.GetString("UserId");

            return View();
        }

        public IActionResult SetTempData()
        {
            // TempData survives one redirect.
            TempData["Success"] =
                "This message came through TempData.";

            // Keep makes it survive one additional read/request.
            TempData.Keep("Success");

            return RedirectToAction("Index");
        }

        public IActionResult PeekTempData()
        {
            // Peek reads without marking the value for deletion.
            ViewBag.PeekedMessage =
                TempData.Peek("Success");

            return View("Index");
        }

        public IActionResult SetCookie()
        {
            HttpContext.Response.Cookies.Append(
                "UserName",
                "Ahmed",
                new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                });

            return RedirectToAction("Index");
        }

        public IActionResult SetSession()
        {
            HttpContext.Session.SetString(
                "UserId",
                "123");

            return RedirectToAction("Index");
        }
    }
}