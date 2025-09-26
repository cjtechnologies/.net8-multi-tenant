using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Data;

namespace MultiTenant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly TenantDbContextFactory _dbContextFactory;

        public MembersController(TenantDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            using var db = _dbContextFactory.CreateDbContext();
            var members = db.Members.ToList();
            return Ok(members);
        }
    }
}
