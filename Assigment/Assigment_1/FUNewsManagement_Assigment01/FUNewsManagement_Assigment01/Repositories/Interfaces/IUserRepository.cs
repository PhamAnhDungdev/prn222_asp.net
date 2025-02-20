using FUNewsManagement_Assigment01.Models;

namespace FUNewsManagement_Assigment01.Repositories.Interfaces
{
    public interface IUserRepository
    {
        // Lấy user theo email - dùng cho đăng nhập
        Task<SystemAccount> GetUserByEmail(string email);

        // Các phương thức CRUD khác
        Task<List<SystemAccount>> GetAllUsers();
        Task<SystemAccount> GetUserById(int id);
        Task<bool> CreateUser(SystemAccount user);
        Task<bool> UpdateUser(SystemAccount user);
        Task<bool> DeleteUser(int id);
    }
}
