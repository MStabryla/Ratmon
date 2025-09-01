using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ratmon.Models;

namespace Ratmon.Controllers
{
    [Route("getdata")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class GetDataController : ControllerBase
    {
        private RatmonDbContext Context { get; set; }

        public GetDataController(RatmonDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        [Route("mouse2")]
        public async Task<IActionResult> GetMouse2([FromQuery] int count)
        {
            Mouse2[] data = count > 0 ? await Context.Mouse2Set.Take(count).ToArrayAsync() : await Context.Mouse2Set.ToArrayAsync();
            return Ok(data);
        }

        [HttpGet]
        [Route("mouse2b")]
        public async Task<IActionResult> GetMouse2B([FromQuery] int count)
        {
            Mouse2B[] data = count > 0 ? await Context.Mouse2BSet.Take(count).ToArrayAsync() : await Context.Mouse2BSet.ToArrayAsync();
            return Ok(data);
        }

        [HttpGet]
        [Route("mousecombo")]
        public async Task<IActionResult> GetMouseCombo([FromQuery] int count)
        {
            MouseCombo[] data = count > 0 ? await Context.MouseComboSet.Include(x => x.Reflectograms).Take(count).ToArrayAsync() : await Context.MouseComboSet.Include(x => x.Reflectograms).ToArrayAsync();
            return Ok(data);
        }

        [HttpGet]
        [Route("mas2")]
        public async Task<IActionResult> GetMas2([FromQuery] int count)
        {
            Mas2[] data = count > 0 ? await Context.Mas2Set.Take(count).ToArrayAsync() : await Context.Mas2Set.ToArrayAsync();
            return Ok(data);
        }
    }
}
