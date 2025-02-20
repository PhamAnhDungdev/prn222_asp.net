using Microsoft.AspNetCore.Mvc;

namespace FUNewsManagement_Assigment01.Controllers
{
    public abstract class BaseController : Controller
    {
        protected string CurrentUserId
        {
            get { return User.FindFirst("UserId")?.Value; }
        }

        // Kiểm tra role của user
        protected bool IsAdmin
        {
            get { return User.IsInRole("Admin"); }
        }

        protected bool IsStaff
        {
            get { return User.IsInRole("Staff"); }
        }
    }
}
