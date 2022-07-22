using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using React.NetCore6SwaggerOdataEntityFramework;
using React.NetCore6SwaggerOdataEntityFramework.Data;

namespace React.NetCore6SwaggerOdataEntityFramework.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ReactNetCore6SwaggerOdataEntityFrameworkContext _context;

        public WeatherForecastController(ReactNetCore6SwaggerOdataEntityFrameworkContext context)
        {
            _context = context;
        }

        // GET: api/WeatherForecast
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetWeatherForecast()
        {
          if (_context.WeatherForecast == null)
          {
              return NotFound();
          }
            return await _context.WeatherForecast.ToListAsync();
        }

        // GET: api/WeatherForecast/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecast>> GetWeatherForecast(Guid id)
        {
          if (_context.WeatherForecast == null)
          {
              return NotFound();
          }
            var weatherForecast = await _context.WeatherForecast.FindAsync(id);

            if (weatherForecast == null)
            {
                return NotFound();
            }

            return weatherForecast;
        }

        // PUT: api/WeatherForecast/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherForecast(Guid id, WeatherForecast weatherForecast)
        {
            if (id != weatherForecast.Id)
            {
                return BadRequest();
            }

            _context.Entry(weatherForecast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherForecastExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WeatherForecast
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeatherForecast>> PostWeatherForecast(WeatherForecast weatherForecast)
        {
          if (_context.WeatherForecast == null)
          {
              return Problem("Entity set 'ReactNetCore6SwaggerOdataEntityFrameworkContext.WeatherForecast'  is null.");
          }
            _context.WeatherForecast.Add(weatherForecast);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeatherForecast", new { id = weatherForecast.Id }, weatherForecast);
        }

        // DELETE: api/WeatherForecast/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherForecast(Guid id)
        {
            if (_context.WeatherForecast == null)
            {
                return NotFound();
            }
            var weatherForecast = await _context.WeatherForecast.FindAsync(id);
            if (weatherForecast == null)
            {
                return NotFound();
            }

            _context.WeatherForecast.Remove(weatherForecast);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherForecastExists(Guid id)
        {
            return (_context.WeatherForecast?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
