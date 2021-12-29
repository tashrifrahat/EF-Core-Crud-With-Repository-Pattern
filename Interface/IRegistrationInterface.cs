using EFCoreCrudWithRepository.Model;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCrudWithRepository.Interface
{
    public interface IRegistrationInterface  
    {
        public Task<ActionResult<List<Registration>>> AddUsers(Registration registration);
        public Task<ActionResult<List<Registration>>> GetAllUsers();
        public Task<ActionResult<Registration>> GetUserbyId(int id);
        public Task<ActionResult<Registration>> UpdateUser(int id, Registration registration);
        public Task<bool> DeleteUser(int id);
    }
}
