using EFCoreCrudWithRepository.Model;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCrudWithRepository.Interface
{
    public interface IRegistrationInterface  
    {
        public Task<List<Registration>> AddUsers(Registration registration);
        public Task<List<Registration>> GetAllUsers();
        public Task<Registration> GetUserbyId(int id);
        public Task<Registration> UpdateUser(int id, Registration registration);
        public Task<bool> DeleteUser(int id);
    }
}
