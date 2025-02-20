using FUNewsManagement_Assigment01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoASPNETCoreMVC.Controllers.Authentication
{
    public class Authentication : Controller
    {
        private readonly FunewsManagementContext _context;
        private readonly ILogger<Authentication> _logger;

        // Thêm MyStockContext vào constructor
        public Authentication(FunewsManagementContext myStockContext, ILogger<Authentication> logger)
        {
            _context = myStockContext;
            _logger = logger;
        }
        public IActionResult Login()
        {
            return View("Login", "Authentication");
        }
        public IActionResult LoginAuthen(string Email, string Password)
        {
            var user = _context.SystemAccounts
                .FirstOrDefault(u => u.AccountEmail == Email && u.AccountPassword == Password);

            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Email hoặc mật khẩu không đúng!";
            ViewBag.Email = Email;
            ViewBag.Password = Password;
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
            var user = _context.SystemAccounts.FirstOrDefault(u => u.AccountEmail == Email);
            if (user != null)
            {
                ViewBag.Error = "Tên đăng nhập đã tồn tại!";
                return View("Register", "Authentication");
            }

            var newUser = new SystemAccount
            {
                AccountEmail = Email,
                AccountPassword = Password,
            };

            try
            {
                _context.SystemAccounts.Add(newUser);
                _context.SaveChanges();
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
