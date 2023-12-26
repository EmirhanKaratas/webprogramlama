using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje.Models.siniflar;
using Proje.ViewModel;

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

                // Kullanıcı TC'si daha önce kullanılmış mı kontrolü
                if (_context.Users.Any(x => x.KullaniciTC == users.KullaniciTC))
                {

                    ModelState.AddModelError("KullaniciTC", "Bu TC kimlik numarası zaten kullanılmış.");
                    return View(users);
                }
                if (_context.Users.Any(x => x.KullaniciAdi == users.KullaniciAdi))
                {
                    ModelState.AddModelError("KullaniciAdi", "Bu kullanıcı adı zaten kullanılmış.");
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

            
            // ModelState.IsValid false olduğu durum
            return View(users);
        }
		[AllowAnonymous]
		[HttpPost]
		public IActionResult Login(ViewUsers users)
        {
        
                // Burada giriş işlemleri gerçekleştirilecek
                // Örneğin, kullanıcı adı ve şifre kontrolü
                Console.WriteLine(users.KullaniciMail);
                var user = _context.Users.FirstOrDefault(x => x.KullaniciMail == users.KullaniciMail && x.KullaniciSifre == users.KullaniciSifre);

                if (user != null)
                {
                    // Giriş başarılı ise, kullanıcıyı bir şekilde işaretleyebilirsiniz.
                    // Örneğin, cookie kullanarak kullanıcıyı işaretleyebilirsiniz.
                    // Bu, ASP.NET Core Identity veya başka bir kimlik doğrulama mekanizması kullanıyorsanız değişebilir.

                    // Örneğin: HttpContext.SignInAsync(user);
                    // Giriş başarılı olduğu takdirde bir sayfaya yönlendirin
                    return RedirectToAction("Index", "Home");
                }
       

            else
            {
				ModelState.AddModelError("KullaniciAdi", "Giriş başarısız.");
			}
         return View(users);
        }


    }
}
