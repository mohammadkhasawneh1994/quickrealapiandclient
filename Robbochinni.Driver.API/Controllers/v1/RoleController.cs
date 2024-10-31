using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Robbochinni.Driver.Business.Operations;
using Robbochinni.Driver.Mag.View;

namespace Robbochinni.Driver.API.Controllers.v1
{
    [Route("v1/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager _rolesManager;

        public RoleController(RoleManager rolesManager)
        {
            _rolesManager = rolesManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleView addRole)
        {
            await _rolesManager.Insert(addRole.Name!);
            return Ok();
        }
    }
}
