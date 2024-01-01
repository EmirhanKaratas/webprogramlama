using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje.Models.siniflar;
using Proje.ViewModel;
using System.Security.Claims;

namespace Proje.Controllers
{

    public class GirisYap : Controller
    {
        private readonly Context _context;

        public GirisYap(Context context, IConfiguration configuration)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(ViewUsers users)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı TC'si daha önce kullanılmış mı kontrolü
                if (_context.Users.Any(x => x.KullaniciTC == users.KullaniciTC))
                {

                    ModelState.AddModelError("KullaniciTC", "Bu TC kimlik numarası zaten kullanılmış.");
                    return View(users);
                }
                if (_context.Users.Any(x => x.KullaniciMail == users.KullaniciMail))
                {
                    ModelState.AddModelError("KullaniciMail", "Bu Kullanici maili zaten kullanılmış.");
                    return View(users);
                }
                // Kullanıcıyı kaydetme işlemi
                var yeniKullanici = new Users
                {
                    KullaniciTC = users.KullaniciTC,
                    KullaniciAdi = users.KullaniciAdi,
                    KullaniciMail = users.KullaniciMail,
                    KullaniciSifre = users.KullaniciSifre,
                    Rol = "user" // Varsayılan olarak kullanıcı rolü ekleniyor

                };

                Console.WriteLine(yeniKullanici.KullaniciTC);

                _context.Users.Add(yeniKullanici);
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
                return RedirectToAction(nameof(Login));

            }
            // ModelState.IsValid false olduğu durum
            return View(users);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task< IActionResult >Login(VİewUsersLogin users)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(x => x.KullaniciMail == users.KullaniciMail && x.KullaniciSifre == users.KullaniciSifre);
                var admin = _context.Admins.FirstOrDefault(x => x.AdminMail == users.KullaniciMail && x.AdminSifre == users.KullaniciSifre);
             

                if (admin != null)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, admin.AdminMail),
                    new Claim(ClaimTypes.Role, admin.Rol)
                };
                    Console.WriteLine(admin.Rol);
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Admin");
                }

               else if (user != null)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.KullaniciAdi),
                    new Claim(ClaimTypes.Anonymous, user.KullaniciTC),
                    new Claim(ClaimTypes.Email, user.KullaniciMail),
                    new Claim(ClaimTypes.Role, user.Rol)
                };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Giriş başarısız ise, TempData ile hata mesajını ayarla
                    TempData["ErrorMessage"] = "Giris basarisiz. Lutfen gecerli bir eposta veya sifre giriniz.";
                }
            }

            // Model doğrulama başarısız olursa, aynı sayfaya geri dönün
            return View(users);
        }



    }
}
