using System;
using Microsoft.AspNetCore.Mvc;
using Modelo.Domain.Entities;
using Modelo.Service.Services;
using Modelo.Service.Validators;

namespace Modelo.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UserController : Controller
    {
        private BaseService<User> service = new BaseService<User>();

        public IActionResult Post([FromBody] User user)
        {
            try
            {
                service.Post<UserValidator>(user);

                return new ObjectResult(user.Id);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Put([FromBody] User user)
        {
            try
            {
                service.Put<UserValidator>(user);

                return new ObjectResult(user);
            }
            catch(ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}