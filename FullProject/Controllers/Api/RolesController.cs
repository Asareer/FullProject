using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FullProject.Models;

namespace FullProject.Controllers.Api
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<ApplicationUser> _roleManager;


        public RolesController(RoleManager<ApplicationUser> roleManager)
        {
            _roleManager = roleManager; 
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
                return NotFound();

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
                throw new Exception();

            return Ok();
        }
    }
}
