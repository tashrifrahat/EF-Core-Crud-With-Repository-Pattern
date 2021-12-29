using EFCoreCrudWithRepository.Interface;
using EFCoreCrudWithRepository.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCrudWithRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationInterface _registrationInterface;

        public RegistrationController(IRegistrationInterface registrationInterface)
        {
            _registrationInterface = registrationInterface;

        }

        [HttpPost]
        public async Task<ActionResult<List<Registration>>> Post(Registration registration)
        {
            return await _registrationInterface.AddUsers(registration);

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Registration>>> GetAll()
        {
            return await _registrationInterface.GetAllUsers();
        }

        [HttpGet("GetbyId")]
        public async Task<ActionResult<Registration>> GetUser_Id(int id)
        {
            return await _registrationInterface.GetUserbyId(id);

        }

        [HttpPut("UpdateUserbyId")]
        public async Task<ActionResult<Registration>>UpdateUserbyId(int id, Registration registration)
        {
            return await _registrationInterface.UpdateUser(id, registration);
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteUser_Id(int id)
        {
            try
            {
                var result= await _registrationInterface.DeleteUser(id);

                if(result == true)
                {
                    return StatusCode(StatusCodes.Status204NoContent, "Successfully deleted!");

                }
                else
                {
                    return BadRequest("Id not Found");
                }

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
            
        }




    }
}
