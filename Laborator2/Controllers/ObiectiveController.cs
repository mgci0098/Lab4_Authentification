using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laborator2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laborator2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObiectiveController : ControllerBase
    {

        private ObiectiveDbContext context;

        public ObiectiveController(ObiectiveDbContext context)
        {
            this.context = context;
        }

        // GET: api/Obiective
        [HttpGet]
        public IEnumerable<Obiectiv> Get(DateTime? from, DateTime? to)
        {
            IQueryable<Obiectiv> result = context.Obiective.Include(o=>o.Comments);

            if (from == null && to == null)
            {
                return result;
            }

            if (from != null)
            {
                result = result.Where(o => o.Deadline >= from);
            }
            if (to != null)
            {
                result = result.Where(o => o.Deadline <= to);
            }

            return result;
        }

        // POST: api/Obiective
        [HttpPost]
        public void Post([FromBody] Obiectiv obiectiv)
        {
            //if (!ModelState.IsValid)
            //{

            //}
            context.Obiective.Add(obiectiv);
            context.SaveChanges();
        }

        // PUT: api/Obiective/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Obiectiv obiectiv)
        {
            var existing = context.Obiective.AsNoTracking().FirstOrDefault(o => o.Id == id);
            if (existing != null)
            {
                //if (obiectiv.Starea.Equals(Obiectiv.Stare.closed))
                if (obiectiv.Starea.Equals(Obiectiv.Stare.closed))
                {
                    obiectiv.closedAt = DateTime.Now;

               }
               
                context.Obiective.Update(obiectiv);
                context.SaveChanges();
                return Ok(obiectiv);


            }

            obiectiv.closedAt = DateTime.Now;
            context.Obiective.Add(obiectiv);
            context.SaveChanges();
            return Ok(obiectiv);
        }



        // DELETE: api/Obiective/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = context.Obiective.FirstOrDefault(obiectiv => obiectiv.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            context.Obiective.Remove(existing);
            context.SaveChanges();
            return Ok();
        }


    }
}