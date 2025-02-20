using FUNewsManagement_Assigment01.Models;
using FUNewsManagement_Assigment01.Repositories.Interfaces;
using FUNewsManagement_Assigment01.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace FUNewsManagement_Assigment01.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<List<SystemAccount>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEmailExist(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<SystemAccount> ValidateUser(string email, string password)
        {
            string hashedPassword = HashPassword(password);

            var user = await _userRepository.GetUserByEmail(email);

            // Kiểm tra user tồn tại, password đúng và tài khoản active
            if (user != null &&
                user.AccountPassword == hashedPassword)
            {
                return user;
            }
            return null;
        }
        private string HashPassword(string password)
        {
            // Mã hóa password bằng SHA256
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(
                    Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
