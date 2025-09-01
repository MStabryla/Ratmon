using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ratmon.Models;

namespace Ratmon.Controllers
{
    [Route("mdata")]
    [ApiController]
    public class MeasureDataController : ControllerBase
    {
        private RatmonDbContext Context { get; set; }

        public MeasureDataController(RatmonDbContext context)
        {
            Context = context;
        }

        [HttpPost]
        [Route("mouse2")]
        public async Task<IActionResult> ReceiveMouse2([FromForm] Mouse2 data)
        {
            await Context.Mouse2Set.AddAsync(data);
            await Context.SaveChangesAsync();
            return Ok(data);
        }

        [HttpPost]
        [Route("mouse2b")]
        public async Task<IActionResult> ReceiveMouse2B([FromForm] Mouse2B data)
        {
            //Walidacja danych
            bool leakLocationValidated = data.LeakLocation >= 0 && data.LeakLocation <= 100;
            string errorResponse = "";
            if (!leakLocationValidated)
                errorResponse += "LeakLocation is out of available range.";
            if(errorResponse.Length > 0)
                return BadRequest(errorResponse);
            await Context.Mouse2BSet.AddAsync(data);
            await Context.SaveChangesAsync();
            return Ok(data);
        }

        [HttpPost]
        [Route("mousecombo")]
        public async Task<IActionResult> ReceiveMouseCombo(MouseCombo data)
        {
            string errorResponse = "";
            bool seriesNumberValidated = data.Reflectograms.All(mc => 0 <= mc.SeriesNumber && mc.SeriesNumber <= 19);
            bool seriesNumberUniquenessValidated = data.Reflectograms.All(mc => !data.Reflectograms.Any(mc2 => mc2 != mc && mc2.SeriesNumber == mc.SeriesNumber) );
            if (!seriesNumberValidated)
                errorResponse += "Not all series numbers are in range [0-19]. ";
            if (!seriesNumberUniquenessValidated)
                errorResponse += "Not all series numbers are unique";

            if(errorResponse.Length > 0)
                return BadRequest(errorResponse);
            await Context.MouseComboSet.AddAsync(data);
            await Context.SaveChangesAsync();
            return Ok(data);
        }

        [HttpPost]
        [Route("mas2")]
        public async Task<IActionResult> ReceiveMas2(Mas2 data)
        {
            string errorResponse = "";
            bool humidityValidated = 0 <= data.Humidity && data.Humidity <= 100;
            if (!humidityValidated)
                errorResponse += "Humidity is not in range [0-100] %";

            if(errorResponse.Length > 0)
                return BadRequest(errorResponse);
            await Context.Mas2Set.AddAsync(data);
            await Context.SaveChangesAsync();
            return Ok(data);
        } 
    }
}
