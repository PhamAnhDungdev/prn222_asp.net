using FUNewsManagement_Assigment01.Models;

namespace FUNewsManagement_Assigment01.Services.Interfaces
{
    public interface IUserService
    {
        // Phương thức kiểm tra đăng nhập
        Task<SystemAccount> ValidateUser(string email, string password);

        // Các phương thức khác
        Task<bool> IsEmailExist(string email);
        Task<List<SystemAccount>> GetAllUsers();
    }
}
