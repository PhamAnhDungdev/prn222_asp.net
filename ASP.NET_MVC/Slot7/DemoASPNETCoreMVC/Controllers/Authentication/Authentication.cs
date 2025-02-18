using DemoASPNETCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoASPNETCoreMVC.Controllers.Authentication
{
    public class Authentication : Controller
    {
        private readonly MyStockContext _myStockContext;
        private readonly ILogger<Authentication> _logger;

        // Thêm MyStockContext vào constructor
        public Authentication(MyStockContext myStockContext, ILogger<Authentication> logger)
        {
            _myStockContext = myStockContext;
            _logger = logger;
        }
        public IActionResult Login()
        {
            return View("Login", "Authentication");
        }
        public IActionResult LoginAuthen(string Email, string Password)
        {
            var user = _myStockContext.Logins
                .FirstOrDefault(u => u.Username == Email && u.Password == Password);

            if (user != null)
            {
                return RedirectToAction("Index", "Home"); // Đăng nhập thành công
            }

            ViewBag.Error = "Email hoặc mật khẩu không đúng!";
            return View("Login", "Authentication");
        }

        public IActionResult Register() //Hàm này để view gọi tới Controller với router localhost:3000/Authentication/Register
        {
            return View("Register", "Authentication");
        }

        public IActionResult RegisterAuthen(string Email, string Password, string ConfirmPassword)
        {
            if (Password != ConfirmPassword)
            {
                ViewBag.Error = "Mật khẩu không giống nhau!";
                return View("Register", "Authentication");
            }
            var user = _myStockContext.Logins.FirstOrDefault(u => u.Username == Email);
            if (user != null)
            {
                ViewBag.Error = "Tên đăng nhập đã tồn tại!";
                return View("Register", "Authentication");
            }

            var newUser = new Login
            {
                Username = Email,
                Password = Password,
            };

            try
            {
                _myStockContext.Logins.Add(newUser);
                _myStockContext.SaveChanges();
                ViewBag.Success = "Đăng ký tài khoản thành công!";
                return RedirectToAction("Login", "Authentication");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Có lỗi xảy ra khi đăng ký: " + ex.Message;
                return View("Register", "Authentication");
            }
        }

        //Redirect tới view //File Register.Razor Folder Views/Authentication
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
