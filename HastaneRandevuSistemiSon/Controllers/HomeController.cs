using HastaneRandevuSistemiSon.Models;
using HastaneRandevuSistemiSon.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HastaneRandevuSistemiSon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private LanguageService _localization;
        public HomeController(ILogger<HomeController> logger, LanguageService localization)
        {
            _localization = localization;
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewBag.WelcomeMessage = _localization.Getkey("Hastane Randevu Sistemi");
            ViewBag.WelcomeMessage = _localization.Getkey("Ana Sayfa");
            ViewBag.WelcomeMessage = _localization.Getkey("Randevular");
            ViewBag.WelcomeMessage = _localization.Getkey("Hastalıklar");
            ViewBag.WelcomeMessage = _localization.Getkey("Doktorlar");
            ViewBag.WelcomeMessage = _localization.Getkey("Birimler");
            ViewBag.WelcomeMessage = _localization.Getkey("Poliklinikler");
            ViewBag.WelcomeMessage = _localization.Getkey("Giriş Yap");
            ViewBag.WelcomeMessage = _localization.Getkey("Kaydol");
            ViewBag.WelcomeMessage = _localization.Getkey("Yeni Randevu Oluştur");
            ViewBag.WelcomeMessage = _localization.Getkey("Tarih");
            ViewBag.WelcomeMessage = _localization.Getkey("Hasta");
            ViewBag.WelcomeMessage = _localization.Getkey("Doktor");
            ViewBag.WelcomeMessage = _localization.Getkey("Oluştur");
            ViewBag.WelcomeMessage = _localization.Getkey("Alzheimer");
            ViewBag.WelcomeMessage = _localization.Getkey("Kızamık");
            ViewBag.WelcomeMessage = _localization.Getkey("Nezle");
            ViewBag.WelcomeMessage = _localization.Getkey("Obezite");
            ViewBag.WelcomeMessage = _localization.Getkey("Kırık");
            ViewBag.WelcomeMessage = _localization.Getkey("Kalp Doktoru");
            ViewBag.WelcomeMessage = _localization.Getkey("Kulak Burun Boğaz Doktoru");
            ViewBag.WelcomeMessage = _localization.Getkey("Akciğer Doktoru");
            ViewBag.WelcomeMessage = _localization.Getkey("Beyin Doktoru");
            ViewBag.WelcomeMessage = _localization.Getkey("Çocuk Doktoru");
            ViewBag.WelcomeMessage = _localization.Getkey("Acil Servis Birimi");
            ViewBag.WelcomeMessage = _localization.Getkey("Cerrahi Servis Birimi");
            ViewBag.WelcomeMessage = _localization.Getkey("Yoğun Bakım Birimi");
            ViewBag.WelcomeMessage = _localization.Getkey("Kulak Burun Boğaz Polikliniği");
            ViewBag.WelcomeMessage = _localization.Getkey("Akciğer Polikliniği");
            ViewBag.WelcomeMessage = _localization.Getkey("Kalp Polikliniği");
            ViewBag.WelcomeMessage = _localization.Getkey("Beyin Polikliniği");
            ViewBag.WelcomeMessage = _localization.Getkey("Çocuk Polikliniği");
            ViewBag.WelcomeMessage = _localization.Getkey("Kullanıcı Adı");
            ViewBag.WelcomeMessage = _localization.Getkey("Şifre");
            ViewBag.WelcomeMessage = _localization.Getkey("Giriş");
            ViewBag.WelcomeMessage = _localization.Getkey("Email");
            ViewBag.WelcomeMessage = _localization.Getkey("Kaydol");
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            return View();
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });
            return Redirect(Request.Headers["Referer"].ToString());
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