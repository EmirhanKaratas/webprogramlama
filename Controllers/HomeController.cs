using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Proje.Models;
using Proje.Models.siniflar;
using Proje.Services;
using Proje.ViewModel;
using System.Diagnostics;
using System.Security.Claims;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace Proje.Controllers
{
   
    [Authorize(Roles = "user")]
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        private readonly Context _context;

        private LanguageService _localization;

        public HomeController(Context context, ILogger<HomeController> logger , LanguageService localization)
        {
            _logger = logger;
            _context = context;
            _localization = localization;
        }
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)

                });
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Index()
        {
            List<Seferler> seferlist = _context.Seferlers.ToList();

            IEnumerable<ViewSeferEkle> seferwiew = seferlist.Select(sefer => new ViewSeferEkle
            {
                SeferId = sefer.SeferlerId,
                güzergah = sefer.güzergah,
                Gün = sefer.Gün,
                Saat = sefer.Saat,
                Fiyat = sefer.Fiyat,
                Image = sefer.Image,
                Kapasite = sefer.Kapasite,
                // Güzergahı iki ayrı değişkene ayırma
                GüzergahSehir1 = sefer.güzergah.Split('-')[0],
                GüzergahSehir2 = sefer.güzergah.Split('-')[1]
            });

            return View(seferwiew);
        }


        public IActionResult SeferAra(string selectpicker, string selectpicker1, DateTime date)
        {

         
            // Veritabanından uygun verileri almak için bir sorgu yapılmalıdır.
            // Bu sorgu, güzergah1 + " " + güzergah2 ifadesiyle eşleşen ve aynı zamanda belirli bir tarihle eşleşen verileri getirmelidir.
            Console.WriteLine(selectpicker, selectpicker1);
            // Örnek bir sorgu (bu sorguyu ihtiyacınıza göre güncellemelisiniz):
            var seferler = _context.Seferlers
                 .Where(sefer => (sefer.güzergah == selectpicker + "-" + selectpicker1) && (sefer.Gün == date))
                 .ToList();
            var model = new List<ViewSeferEkle>();
            foreach (var sefer in seferler)
            {
                model.Add(new ViewSeferEkle
                {
                    SeferId = sefer.SeferlerId,
                    güzergah = sefer.güzergah,
                    Gün = date,
                    Saat = sefer.Saat,
                    Fiyat = sefer.Fiyat,
                    Image = sefer.Image,
                    Kapasite = sefer.Kapasite
                });
            }

            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Hata() 
        {
            return View();
        }
        public IActionResult Odeme(Nullable<int> id)
        {
            // Sefer ID'sini kullanarak Seferleri bul
            Seferler sefer = _context.Seferlers.Find(id);

            // Cookies verilerini çek
            var userEmailClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var tc = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Anonymous)?.Value;
            var kullaniciadi = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;


            var users = _context.Users.Where(u => u.KullaniciTC == tc).ToList();

            ViewBag.userlist = users;           



            // Diğer cookies verilerini çek

            // ViewBag'e kullanıcı adını ekle


            // Sefer nesnesini SeferViewModel'e dönüştür
            ViewSeferEkle seferViewModel = new ViewSeferEkle
            {
                SeferId = sefer.SeferlerId,
                güzergah = sefer.güzergah,
                Gün = sefer.Gün,
                Saat = sefer.Saat,
                Fiyat = sefer.Fiyat,
                Image = sefer.Image,
                Kapasite = sefer.Kapasite,
                // Diğer özellikleri atayın
            };

            // View'e SeferViewModel'i ve ViewBag verilerini gönderin
            return View(seferViewModel);
        }
        [HttpPost]
        public  IActionResult Biletler(string kullaniciAdi, string KullaniciMail, string KullaniciTc, string kapasite, string Gün, string saat,string güzergah) 
        {
            Console.WriteLine(kapasite);

            if (_context.biletlers.Any(b => b.koltuk.ToLower() == kapasite))
            {
                
               
                return RedirectToAction("Hata", "Home");
            }
            else
            {
                var yeniKullanici = new Biletler
                {
                    KullaniciTc = KullaniciTc,
                    KullaniciAdi = kullaniciAdi,
                    KullaniciEmail = KullaniciMail,
                    güzergah = güzergah,
                    Gün = Gün,
                    zaman = saat,
                    koltuk = kapasite,

                };



                _context.biletlers.Add(yeniKullanici);
                _context.SaveChanges();

                return RedirectToAction("Profil", "Home");
            }
        }
        public async Task<IActionResult> Profil()
        {
            // Kullanıcının kimliğini al
            var tc = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Anonymous)?.Value;

            // API endpoint'inin sonunda kullanıcının ID'sini ekleyerek istek yapma işlemi
            string apiUrl = $"https://localhost:7060/api/BiletlerApi/{tc}";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(apiUrl);

                if (!string.IsNullOrEmpty(response))
                {
                    // String veriyi JSON'a dönüştür
                    var postmanData = JsonConvert.DeserializeObject<List<Biletler>>(response);


                    return View(postmanData);
                }
                else
                {
                    return View("Error");
                }
            }
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Yardım()
        {
            return View();
        }
        public IActionResult Seferler()
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
