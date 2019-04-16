using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasprof.Components.SpotifyChart.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpotifyChart.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyChartsController : Controller
    {
        private readonly SpotifyChartDbContext _dbContext;

        public SpotifyChartsController(SpotifyChartDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // GET: api/spotifycharts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasprof.Components.SpotifyChart.Models.SpotifyChart>>> Get()
        {
            var result = await _dbContext.SpotifyCharts.ToListAsync();
            return Ok(result);
        }

        // GET api/spotifycharts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tasprof.Components.SpotifyChart.Models.SpotifyChart>> Get(int id)
        {
            var result = await _dbContext.SpotifyCharts.FindAsync(id);
            return Ok(result);
        }

        // POST api/spotifycharts
        [HttpPost]
        public async Task<ActionResult<Tasprof.Components.SpotifyChart.Models.SpotifyChart>> Post(Tasprof.Components.SpotifyChart.Models.SpotifyChart value)
        {
            _dbContext.SpotifyCharts.Add(value);
            _dbContext.SpotifyChartItems.AddRange(value.Items);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction("Chart", value);
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
