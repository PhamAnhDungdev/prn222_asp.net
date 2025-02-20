using FUNewsManagement_Assigment01.Controllers;
using FUNewsManagement_Assigment01.Models;
using FUNewsManagement_Assigment01.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using System.ComponentModel.DataAnnotations;

namespace DemoASPNETCoreMVC.Controllers.Authentication
{
    public class Authentication : BaseController
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly FunewsManagementContext _context;
        private readonly ILogger<Authentication> _logger;

        // Thêm MyStockContext vào constructor
        public Authentication(IUserService userService,
        IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            Debug.WriteLine(User);
            // Nếu đã đăng nhập, chuyển đến trang chủ
            if (User.Identity.IsAuthenticated)
            {
                //return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            // ModelState là một thuộc tính trong ASP.NET MVC dùng để xác thực(validate) dữ liệu của model.
            // Nó chứa trạng thái validation của model và các thông báo lỗi.
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Kiểm tra tài khoản admin từ config
            var adminEmail = _configuration["AdminAccount:Email"];
            var adminPassword = _configuration["AdminAccount:Password"];

            if (model.Email == adminEmail &&
                model.Password == adminPassword)
            {
                // Đăng nhập với quyền admin
                await SignInUser(model.Email, "Admin", "0");
                return RedirectToAction("Index", "Home");
            }

            // Kiểm tra user thường
            var user = await _userService.ValidateUser(
                model.Email, model.Password);

            if (user != null)
            {
                string role = user.AccountRole == 1 ? "Staff" : "Lecturer";
                await SignInUser(
                    user.AccountEmail,
                    role,
                    user.AccountId.ToString());

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Email hoặc mật khẩu không đúng");
            return View(model);
        }

        // Phương thức tạo cookie đăng nhập
        private async Task SignInUser(
            string email,
            string role,
            string userId
        )
        {
            // Tạo danh sách claims
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, email),
            new Claim(ClaimTypes.Role, role),
            new Claim("UserId", userId)
        };

            // Tạo identity
            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            // Cấu hình cookie
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            };

            // Tạo cookie đăng nhập
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            // Debug sau khi tạo cookie
            Debug.WriteLine("=== User Authentication Info ===");
            Debug.WriteLine($"Authentication Type: {HttpContext.User.Identity?.AuthenticationType}");
            Debug.WriteLine($"Is Authenticated: {HttpContext.User.Identity?.IsAuthenticated}");

            // Log tất cả claims
            Debug.WriteLine("Claims:");
            foreach (var claim in claims)
            {
                Debug.WriteLine($"- {claim.Type}: {claim.Value}");
            }

            // Log cookie
            Debug.WriteLine("Cookies:");
            foreach (var cookie in HttpContext.Request.Cookies)
            {
                Debug.WriteLine($"- {cookie.Key}: {cookie.Value}");
            }
        }

        public async Task<IActionResult> Logout()
        {
            // Xóa cookie đăng nhập
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
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
