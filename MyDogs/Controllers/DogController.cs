using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly DogContext _context;

        public DogController(DogContext context)
        {
            _context = context;
        }

        // GET: api/Dogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dog>>> GetDogs()
        {
            return await _context.Dogs.ToListAsync();
        }

        // GET: api/Dogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dog>> GetDog(int id)
        {
            var dog = await _context.Dogs.FindAsync(id);

            if (dog == null)
            {
                return NotFound();
            }

            return dog;
        }

        // GET: api/Dogs/Race/race
        [HttpGet("Race/{race}")]
        public async Task<ActionResult<IEnumerable<Dog>>> GetDogsInOrderByName(string race)
        {
            var dogs = await _context.Dogs.ToListAsync();
            var query = from d in dogs
                        where d.Race == race
                        orderby d.Name ascending
                        select d;
            return query.ToList();

        }

        // GET: api/Dogs/Age/ageMax,ageMin
        [HttpGet("Age/{ageMax},{ageMin}")]
        public async Task<ActionResult<IEnumerable<Dog>>> GetDogsByAge(int ageMax, int ageMin)
        {
            var dogs = await _context.Dogs.ToListAsync();
            var query2 = from d in dogs
                        where d.Age <= ageMax && d.Age >= ageMin
                        orderby d.Name ascending
                        select d;
            return query2.ToList();

        }

        // GET: api/Dogs/Poids/weightMax,weightMin
        [HttpGet("Poids/{weightMax},{weightMin}")]
        public async Task<ActionResult<IEnumerable<Dog>>> GetDogsByWeight(int weightMax, int weightMin)
        {
            var dogs = await _context.Dogs.ToListAsync();
            var query3 = from d in dogs
                         where d.Poids <= weightMax && d.Poids >= weightMin
                         orderby (d.Age, d.Poids) descending
                         select d;
            return query3.ToList();
        }

        // GET: api/Dogs/Name/name
        [HttpGet("Name/{name}")]
        public async Task<ActionResult<IEnumerable<Dog>>> GetDogsByName(string name)
        {
            var dogs = await _context.Dogs.ToListAsync();
            var query4 = from d in dogs
                        where d.Name.ToLower().Contains(name)
                        select d;
            return query4.ToList();

        }



        // POST: api/Dog
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dog>> PostDog(Dog dog)
        {
            _context.Dogs.Add(dog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDog", new { id = dog.DogId }, dog);
        }

        // PUT: api/Dog/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDog(int id, Dog dog)
        {
            if (id != dog.DogId)
            {
                return BadRequest();
            }

            _context.Entry(dog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogExists(id))
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

        // DELETE: api/Dogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogs(int id)
        {
            var dog = await _context.Dogs.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }

            _context.Dogs.Remove(dog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DogExists(int id)
        {
            return _context.Dogs.Any(e => e.DogId == id);
        }
    }
}
