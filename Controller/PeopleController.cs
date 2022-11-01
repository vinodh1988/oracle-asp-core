using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OracleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace OracleAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class PeopleController : ControllerBase
    {
        private OracleDBContext _context;
        public PeopleController(OracleDBContext context) {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {

            return await _context.people.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Person>>> Post(Person person)
        {

            _context.Add(person);

            try
            {
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, person);
            }

            catch (DbUpdateException)
            {
                if (PersonExists(person.Sno))
                    return Conflict();
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, new
                    {
                        message = "Server Error"
                    });
            }
        }

        [HttpPut("{sno}")]
        public async Task<ActionResult<Person>> Put(short sno,  Person person)
        {
            if (PersonExists(sno))
            {
                try
                {
                    Person existing = await this._context.people.FirstOrDefaultAsync(m => m.Sno == sno);
                   
                    existing.Name = person.Name == null ? existing.Name : person.Name;
                    existing.City = person.City == null ? existing.City : person.City;
                    this._context.Update(existing);
                    await this._context.SaveChangesAsync();
                    return existing;
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message + " " + e.StackTrace);
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            else
                return StatusCode(StatusCodes.Status204NoContent);
          
        }

        private bool PersonExists(int id)
        {
            return _context.people.Any(e => e.Sno == id);
        }

    }
}
