using IOTBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IOTBackend.Controllers
{
    [ApiController]
    [Route("lights")]
    public class LightController : ControllerBase
    {
        private readonly DatabaseContext databaseContext;
        private readonly ILogger<LightController> logger;

        public LightController(DatabaseContext dc, ILogger<LightController> logger)
        {
            databaseContext = dc;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<Light>> Create(Light light)
        {
            await databaseContext.Lights.AddAsync(light);

            await databaseContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id =  light.Id}, light);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Light>>> List()
        {
            var lights = await databaseContext.Lights.ToListAsync();

            logger.LogInformation(Request.Host.Host);

            return Ok(lights);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Light>> Get(Guid id)
        {
            var light = await databaseContext.Lights.SingleOrDefaultAsync(x => x.Id == id);

            if (light == null)
            {
                return NotFound(light);
            }

            return Ok(light);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<Light>> Update(Guid id, Light light)
        {
            var found = await databaseContext.Lights.SingleOrDefaultAsync(x => x.Id == id);

            if (found == null)
            {
                return NotFound(found);
            }

            found.Name = light.Name;
            found.IsOn = light.IsOn;

            await databaseContext.SaveChangesAsync();

            return Ok(found);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<Light>> Delete(Guid id)
        {
            var found = await databaseContext.Lights.SingleOrDefaultAsync(x => x.Id == id);

            if (found == null)
            {
                return NotFound(found);
            }

            databaseContext.Remove(found);
            await databaseContext.SaveChangesAsync();

            return found;
        }
    }
}
