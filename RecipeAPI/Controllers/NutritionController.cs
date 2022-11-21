using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeAPI.Models;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionController : ControllerBase
    {
        private readonly RecipeAPIDBContext _context;

        public NutritionController(RecipeAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Nutrition
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Nutrition>>> GetNutrition()
        //{
        //  if (_context.Nutrition == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Nutrition.ToListAsync();
        //}
        public async Task<Response> GetNutrition()
        {
            Response a = new Response();
            if (_context.Nutrition == null || _context.Recipes.Count() == 0)
            {
                //a.statusCode = 404;
                a.statusCode = NotFound().StatusCode;
                a.statusDescription = "COULD NOT FIND TABLE: NUTRITION";
                return a;
            }
            //a.statusCode = 200;
            a.statusCode = Ok().StatusCode;
            a.statusDescription = "SUCCESSFULLY FOUND NUTRITIONAL FACTS";
            a.returnList = await _context.Nutrition.ToListAsync();

            return a;
        }

        // GET: api/Nutrition/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Nutrition>> GetNutrition(int id)
        //{
        //  if (_context.Nutrition == null)
        //  {
        //      return NotFound();
        //  }
        //    var nutrition = await _context.Nutrition.FindAsync(id);

        //    if (nutrition == null)
        //    {
        //        return NotFound();
        //    }

        //    return nutrition;
        //}
        public async Task<Response> GetNutrition(int id)
        {
            Response a = new Response();
            if (_context.Nutrition == null)
            {
                //a.statusCode = 404;
                a.statusCode = NotFound().StatusCode;
                a.statusDescription = "COULD NOT FIND TABLE: NUTRITION";
                return a;
            }

            var nutrition = await _context.Nutrition.FindAsync(id);

            if (nutrition == null)
            {
                a.statusCode = NotFound().StatusCode;
                a.statusDescription = "NUTRITIONAL FACT WITH ID: " + id + ", NOT FOUND";
                return a;
            }
            //a.statusCode = 200;
            a.statusCode = Ok().StatusCode;
            a.statusDescription = "NUTRITIONAL FACT WITH ID: " + id + ", FOUND";
            a.returnList = nutrition;

            return a;
        }

        // PUT: api/Nutrition/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //public async Task<IActionResult> PutNutrition(int id, Nutrition nutrition)
        //{
        //    if (id != nutrition.NutritionID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(nutrition).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!NutritionExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
        public async Task<Response> PutNutrition(int id, Nutrition nutrition)
        {
            Response a = new Response();

            if (_context.Nutrition == null)
            {
                //a.statusCode = 404;
                a.statusCode = NotFound().StatusCode;
                a.statusDescription = "COULD NOT FIND TABLE: NUTRITION. COULD NOT MODIFY";
                return a;
            }

            if (id != nutrition.NutritionID)
            {
                a.statusCode = BadRequest().StatusCode;
                a.statusDescription = "INVALID ID";
                return a;
            }

            _context.Entry(nutrition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NutritionExists(id))
                {
                    a.statusCode = NotFound().StatusCode;
                    a.statusDescription = "NUTRITIONAL FACT WITH ID: " + id + ", NOT FOUND. COULD NOT MODIFY";
                    return a;
                }
                else
                {
                    throw;
                }
            }
            a.statusCode = NoContent().StatusCode;
            a.statusDescription = "NUTRITIONAL FACT WITH ID: " + id + ", SUCCESSFULLY MODIFIED";
            return a;
        }

        // POST: api/Nutrition
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //public async Task<ActionResult<Nutrition>> PostNutrition(Nutrition nutrition)
        //{
        //  if (_context.Nutrition == null)
        //  {
        //      return Problem("Entity set 'RecipeAPIDBContext.Nutrition'  is null.");
        //  }
        //    _context.Nutrition.Add(nutrition);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetNutrition", new { id = nutrition.NutritionID }, nutrition);
        //}
        //public async Task<Response> PostNutrition(Nutrition nutrition)
        //{
        //    Response a = new Response();
        //    if (_context.Nutrition == null)
        //    {
        //        a.statusCode = NotFound().StatusCode;
        //        a.statusDescription = "COULD NOT FIND TABLE: NUTRITION. COULD NOT ADD NEW NUTRITIONAL FACT";
        //        return a;
        //    }

        //    if (NutritionExists(nutrition.NutritionID))
        //    {
        //        a.statusCode = 409;
        //        a.statusDescription = "NUTRITIONAL FACT WITH ID: " + nutrition.NutritionID + ", ALREADY EXISTS";
        //        return a;
        //    }

        //    _context.Nutrition.Add(nutrition);
        //    await _context.SaveChangesAsync();

        //    a.statusCode = 201;
        //    a.statusDescription = "NUTRITIONAL FACT WITH ID: " + nutrition.NutritionID + ", SUCCESSFULLY CREATED";
        //    a.returnList = nutrition;

        //    return a;
        //}

        // DELETE: api/Nutrition/5
        [HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteNutrition(int id)
        //{
        //    if (_context.Nutrition == null)
        //    {
        //        return NotFound();
        //    }
        //    var nutrition = await _context.Nutrition.FindAsync(id);
        //    if (nutrition == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Nutrition.Remove(nutrition);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
        //public async Task<Response> DeleteNutrition(int id)
        //{
        //    Response a = new Response();
        //    if (_context.Nutrition == null)
        //    {
        //        a.statusCode = NotFound().StatusCode;
        //        a.statusDescription = "COULD NOT FIND TABLE: NUTRITION. COULD NOT DELETE";
        //        return a;
        //    }
        //    var nutrition = await _context.Nutrition.FindAsync(id);

        //    if (nutrition == null)
        //    {
        //        a.statusCode = NotFound().StatusCode;
        //        a.statusDescription = "NUTRITIONAl FACT WITH ID: " + id + ", NOT FOUND";
        //        return a;
        //    }

        //    _context.Nutrition.Remove(nutrition);

        //    await _context.SaveChangesAsync();

        //    a.statusCode = NoContent().StatusCode;
        //    a.statusDescription = "NUTRITIONAL FACT WITH ID: " + id + ", SUCCESSFULLY REMOVED";

        //    return a;
        //}

        private bool NutritionExists(int id)
        {
            return (_context.Nutrition?.Any(e => e.NutritionID == id)).GetValueOrDefault();
        }
    }
}
