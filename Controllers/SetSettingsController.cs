using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ratmon.Models;

namespace Ratmon.Controllers
{
    [Route("settings")]
    [ApiController]
    [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SetSettingsController : ControllerBase
    {
        private RatmonDbContext Context { get; set; }

        public SetSettingsController(RatmonDbContext context)
        {
            Context = context;
        }


        [HttpPut]
        [Route("mouse2")]
        public async Task<IActionResult> ReceiveMouse2(Mouse2_Config data)
        {
            Mouse2_Config? config = null;
            if (await Context.Mouse2_Config.AnyAsync())
                config = await Context.Mouse2_Config.FirstOrDefaultAsync(x => x.Name == data.Name);
            if (config != null)
            {
                config.Threshold = data.Threshold;
            }
            else
                await Context.Mouse2_Config.AddAsync(data);
            await Context.SaveChangesAsync();

            return Ok(await Context.Mouse2_Config.FirstAsync(x => x.Name == data.Name));
        }

        [HttpPut]
        [Route("mouse2b")]
        public async Task<IActionResult> ReceiveMouse2B(Mouse2B_Config data)
        {
            Mouse2B_Config? config = null;
            if (await Context.Mouse2B_Config.AnyAsync())
                config = await Context.Mouse2B_Config.FirstOrDefaultAsync(x => x.Name == data.Name);
            if (config != null)
            {
                config.Threshold = data.Threshold;
                config.WireLength = data.WireLength;
            }
            else
                await Context.Mouse2B_Config.AddAsync(data);
            await Context.SaveChangesAsync();

            return Ok(await Context.Mouse2B_Config.FirstAsync(x => x.Name == data.Name));
        }

        [HttpPut]
        [Route("mousecombo")]
        public async Task<IActionResult> ReceiveMouseCombo(MouseCombo_Config data)
        {
            MouseCombo_Config? config = null;
            if (await Context.MouseCombo_Config.AnyAsync())
                config = await Context.MouseCombo_Config.FirstOrDefaultAsync(x => x.Name == data.Name);
            if (config != null)
            {
                config.Threshold = data.Threshold;
            }
            else
                await Context.MouseCombo_Config.AddAsync(data);
            await Context.SaveChangesAsync();

            return Ok(await Context.MouseCombo_Config.FirstAsync(x => x.Name == data.Name));
        }

        [HttpPut]
        [Route("mas2")]
        public async Task<IActionResult> ReceiveMas2(Mas2_Config data)
        {
            Mas2_Config? config = null;
            if (await Context.Mas2_Config.AnyAsync())
                config = await Context.Mas2_Config.FirstOrDefaultAsync(x => x.Name == data.Name);
            if (config != null)
            {
                config.TemperatureThreshold = data.TemperatureThreshold;
                config.HumidityThreshold = data.HumidityThreshold;
            }
            else
                await Context.Mas2_Config.AddAsync(data);
            await Context.SaveChangesAsync();

            return Ok(await Context.Mas2_Config.FirstAsync(x => x.Name == data.Name));
        }
    }
}
