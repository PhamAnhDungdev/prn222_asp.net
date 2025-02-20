using FUNewsManagement_Assigment01.Models;
using FUNewsManagement_Assigment01.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FUNewsManagement_Assigment01.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {

        private readonly FunewsManagementContext _context; // DbContext của bạn

        public UserRepository(FunewsManagementContext context)
        {
            _context = context;
        }

        public Task<bool> CreateUser(SystemAccount user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SystemAccount>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<SystemAccount> GetUserByEmail(string email)
        {
            return await _context.SystemAccounts.FirstOrDefaultAsync(u => u.AccountEmail == email);
        }

        public Task<SystemAccount> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(SystemAccount user)
        {
            throw new NotImplementedException();
        }
    }
}
