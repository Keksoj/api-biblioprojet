using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiblioApi;
using BiblioApi.Utilities;
using BiblioApi.Models;
using System.Net;

namespace BiblioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly DBContext _context;

        public struct Link
        {
            public int artistId { get; set; }
            public int groupId { get; set; }
        }

        public ArtistsController(DBContext context)
        {
            _context = context;
        }

        // Get: api/Artist/5/Link
        [HttpPost("{artistId}/Link")]
        public async Task<ActionResult<string>> LinkArtistToGroupAsync(int artistId, int groupId)
        {
            // First search the artist with id
            var artist = await _context.Artists.FindAsync(artistId);
            if (artist == null) return new CustomJsonResponse($"Artist with id {artistId} not found", HttpStatusCode.NotFound);

            // Check if group exist
            var group = await _context.Groups.FindAsync(groupId);
            if (group == null) return new CustomJsonResponse($"Group with id {groupId} not found", HttpStatusCode.NotFound);

            return $"Artist id is {artistId}, Group id is {groupId}";
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return await _context.Artists.ToListAsync();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(long id)
        {
            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
            {
                return NotFound();
            }

            return artist;
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(long id, Artist artist)
        {
            if (id != artist.Id)
            {
                return BadRequest();
            }

            _context.Entry(artist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
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

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            Console.WriteLine("coucou");
            // Should i use a custom Task for that ?
            // Search artist with the same name in the DB
            // var currentArtist = await Utils.FirstOrDefaultAsync(_context.Artists, (a) => a.ArtistName == artist.ArtistName);
            // that was false yes, sorry

            artist.DateCreation = DateTime.Now;

            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtist", new { id = artist.Id }, artist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(long id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtistExists(long id)
        {
            return _context.Artists.Any(e => e.Id == id);
        }
    }
}