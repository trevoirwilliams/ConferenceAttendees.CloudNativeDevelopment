using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConferenceAttendees.Api.Data;

namespace ConferenceAttendees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferralSourcesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReferralSourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ReferralSources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReferralSource>>> GetReferralSources()
        {
            return await _context.ReferralSources.ToListAsync();
        }

        // GET: api/ReferralSources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReferralSource>> GetReferralSource(Guid id)
        {
            var referralSource = await _context.ReferralSources.FindAsync(id);

            if (referralSource == null)
            {
                return NotFound();
            }

            return referralSource;
        }

        // PUT: api/ReferralSources/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReferralSource(Guid id, ReferralSource referralSource)
        {
            if (id != referralSource.Id)
            {
                return BadRequest();
            }

            _context.Entry(referralSource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferralSourceExists(id))
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

        // POST: api/ReferralSources
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReferralSource>> PostReferralSource(ReferralSource referralSource)
        {
            _context.ReferralSources.Add(referralSource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReferralSource", new { id = referralSource.Id }, referralSource);
        }

        // DELETE: api/ReferralSources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReferralSource(Guid id)
        {
            var referralSource = await _context.ReferralSources.FindAsync(id);
            if (referralSource == null)
            {
                return NotFound();
            }

            _context.ReferralSources.Remove(referralSource);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReferralSourceExists(Guid id)
        {
            return _context.ReferralSources.Any(e => e.Id == id);
        }
    }
}
