using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FuelTracker.Domain.Models;

namespace FuelTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;

        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        [Route("GetUserProfile")]
        // GET:api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            try
            {
                string UserId = User.Claims.First(c => c.Type == "UserID").Value;
                var user = await _userManager.FindByIdAsync(UserId);
                return new
                {
                    user.FullName,
                    user.Email,
                    user.UserName,
                    user.Id

                };
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
