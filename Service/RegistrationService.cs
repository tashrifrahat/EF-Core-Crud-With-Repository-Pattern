using EFCoreCrudWithRepository.Data;
using EFCoreCrudWithRepository.Interface;
using EFCoreCrudWithRepository.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EFCoreCrudWithRepository.Service
{
    public class RegistrationService : IRegistrationInterface
    {
        private readonly DataContext _dataContext;
        public RegistrationService(DataContext dataContext)
        {
            _dataContext = dataContext;
               
        }
        public async Task<ActionResult<List<Registration>>> AddUsers(Registration registration)
        {
            _dataContext.Users.Add(registration);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<ActionResult<List<Registration>>> GetAllUsers()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<ActionResult<Registration>> GetUserbyId(int id)
        {
            var x = await _dataContext.Users.FindAsync(id);
            if (x == null)
                Debug.WriteLine("Id not found");
            //await _dataContext.SaveChangesAsync();
            return x;
        }
        public async Task<ActionResult<Registration>> UpdateUser(int id, Registration registration)
        {
         
            var user = await _dataContext.Users.FindAsync(id);

            if (user == null)
                Debug.WriteLine("Id not found");
            user.Name = registration.Name;
            user.UserName = registration.UserName;
            user.Phone = registration.Phone;
            user.Password = registration.Password;
            return user;
            
           
        }
        public async Task<bool> DeleteUser(int id)
        {
            if (id <= 0)
            {
                Debug.WriteLine("Id not found");
                return false;
            }
            
            var user = await _dataContext.Users.FindAsync(id);

            if(user==null)
            {
                Debug.WriteLine("not found");
                return false;

            }
            _dataContext.Users.Remove(user);
            return await _dataContext.SaveChangesAsync() > 0;

        }
    }
}
