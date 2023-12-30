
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using Proje.Models.siniflar;
using Proje.ViewModel;
using System.Numerics;

namespace Proje.Controllers
{

    public class AdminController : Controller
    {

        private readonly Context _context;

        public AdminController(Context context, IConfiguration configuration)
        {
            _context = context;
        }


        [AllowAnonymous]
        public IActionResult KullaniciSil(string? Id)
        {
            Users user = _context.Users.Find(Id);


            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Kullanicilar));

        }

        [AllowAnonymous]
        public IActionResult Kullanicilar()
        {
            List<Users> userlist = _context.Users.ToList();


            IEnumerable<ViewUsers> userwiew = userlist.Select(user => new ViewUsers
            {

                KullaniciTC = user.KullaniciTC,
                KullaniciAdi = user.KullaniciAdi,
                KullaniciMail = user.KullaniciMail,
                KullaniciSifre = user.KullaniciSifre

            });

            return View(userwiew);
        }

        public IActionResult Ucuslar()
        {
            return View();
        }

        public IActionResult SeferEkle()
        {
            var guzergah = _context.Güzergahs.ToList();
            ViewBag.guzergahList = guzergah;

            return View();

        }
        [HttpPost]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult SeferEkle1(ViewSeferEkle sefer)
        {

            // Kullanıcı TC'si daha önce kullanılmış mı kontrolü

            // Kullanıcıyı kaydetme işlemi
            var yeniKullanici1 = new Seferler
            {
                Image = sefer.Image,
                güzergah=sefer.güzergah,
                Gün = sefer.Gün,
                Saat =sefer.Saat,
                Fiyat=sefer.Fiyat,
                Kapasite=sefer.Kapasite,
            };

            _context.Seferlers.Add(yeniKullanici1);
            try
            {
                // Değişiklikleri kaydetmeye çalışın
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Inner exception'ı yazdırın
                Console.WriteLine(ex.InnerException?.Message);
            }
            return RedirectToAction(nameof(SeferEkle));

            return View(sefer);
        }
        public IActionResult SeferGoruntule()
        {
            List<Seferler> seferlist = _context.Seferlers.ToList();

            // Convert Appointments to AppointmentViewModel
            IEnumerable<ViewSeferEkle> seferview = seferlist.Select(sefer => new ViewSeferEkle
            {
                SeferId = sefer.SeferlerId,
                güzergah=sefer.güzergah,
                Gün = sefer.Gün,
                Saat = sefer.Saat,
                Fiyat = sefer.Fiyat,
                Image = sefer.Image,
                Kapasite = sefer.Kapasite,


            }) ; 

            return View(seferview);
        }
        public IActionResult SeferSil(int? id) 
        {
            Seferler sefer = _context.Seferlers.Find(id);


            if (sefer != null)
            {
                _context.Seferlers.Remove(sefer);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(SeferGoruntule));

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GuzergahEkle(ViewGuzergahEkle guzergah)
        {

            if (_context.Güzergahs.Any(x => x.Sehirler == guzergah.Sehirler))
            {

                ModelState.AddModelError("Sehirler", "Bu guzergah zaten eklenmis");
                return View(guzergah);
            }
            // Kullanıcıyı kaydetme işlemi
            var yeniKullanici = new Güzergah
            {
                Sehirler = guzergah.Sehirler

            };

            _context.Güzergahs.Add(yeniKullanici);
            try
            {
                // Değişiklikleri kaydetmeye çalışın
                _context.SaveChanges();
                return RedirectToAction(nameof(GuzergahEkle));
            }
            catch (DbUpdateException ex)
            {
                // Inner exception'ı yazdırın
                Console.WriteLine(ex.InnerException?.Message);
            }
            return View(guzergah);
        }
        public IActionResult GuzergahGoruntule()
        {

            List<Güzergah> güzergahlist = _context.Güzergahs.ToList();

            // Convert Appointments to AppointmentViewModel
            IEnumerable<ViewGuzergahEkle> güzergahview = güzergahlist.Select(güzergah => new ViewGuzergahEkle
            {
                GuzergahId = güzergah.GüzergahId,
                Sehirler = güzergah.Sehirler,


            });

            return View(güzergahview);
        }

        public IActionResult GuzergahSil(int? Id)
        {
            Güzergah güzergah = _context.Güzergahs.Find(Id);


            if (güzergah != null)
            {
                _context.Güzergahs.Remove(güzergah);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(GuzergahGoruntule));

        }
    }
}
