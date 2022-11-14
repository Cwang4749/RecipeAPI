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
    public class RecipeController : ControllerBase
    {
        private readonly RecipeAPIDBContext _context;

        public RecipeController(RecipeAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Recipe
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        //{
        //  if (_context.Recipes == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Recipes.Include(r => r.Nutrition).ToListAsync();
        //}
        public async Task<Response> GetRecipes()
        {
            Response a = new Response();
            if(_context.Recipes == null)
            {
                //a.statusCode = 404;
                a.statusCode = NotFound().StatusCode;
                a.statusDescription = "COULD NOT FIND TABLE: RECIPES";
                return a;
            }
            //a.statusCode = 200;
            a.statusCode = Ok().StatusCode;
            a.statusDescription = "SUCCESSFULLY FOUND RECIPES";
            a.returnList = await _context.Recipes.Include(r => r.Nutrition).ToListAsync();

            return a;
        }

        // GET: api/Recipe/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Recipe>> GetRecipe(int id)
        //{
        //    if (_context.Recipes == null)
        //    {
        //        return NotFound();
        //    }
        //    var recipe = await _context.Recipes.Include(r => r.Nutrition).FirstOrDefaultAsync(r => r.RecipeID == id);

        //    if (recipe == null)
        //    {
        //        var error = "404 ERROR. ID: ";
        //        error += id;
        //        error += ", NOT FOUND";
        //        return NotFound(error);
        //    }

        //    return recipe;
        //}
        public async Task<Response> GetRecipe(int id)
        {
            Response a = new Response();
            if (_context.Recipes == null)
            {
                //a.statusCode = 404;
                a.statusCode = NotFound().StatusCode;
                a.statusDescription = "COULD NOT FIND TABLE: RECIPES";
                return a;
            }

            var recipe = await _context.Recipes.Include(r => r.Nutrition).FirstOrDefaultAsync(r => r.RecipeID == id);
            
            if (recipe == null)
            {
                //a.statusCode = 404;
                a.statusCode = NotFound().StatusCode;
                a.statusDescription = "RECIPE WITH ID: " + id + ", NOT FOUND";
                return a;
            }
            //a.statusCode = 200;
            a.statusCode = Ok().StatusCode;
            a.statusDescription = "RECIPE WITH ID: " + id + ", FOUND";
            a.returnList = recipe;

            return a;
        }

        // PUT: api/Recipe/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //public async Task<IActionResult> PutRecipe(int id, Recipe recipe)
        //{
        //    if (id != recipe.RecipeID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(recipe).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RecipeExists(id))
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
        //public async Task<Response> PutRecipe(int id, Recipe recipe)
        //{
        //    Response a = new Response();

        //    if (_context.Recipes == null)
        //    {
        //        //a.statusCode = 404;
        //        a.statusCode = NotFound().StatusCode;
        //        a.statusDescription = "COULD NOT FIND TABLE: RECIPES. COULD NOT MODIFY";
        //        return a;
        //    }

        //    if (id != recipe.RecipeID)
        //    {
        //        a.statusCode = BadRequest().StatusCode;
        //        a.statusDescription = "INVALID ID";
        //        return a;
        //    }

        //    _context.Entry(recipe).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RecipeExists(id))
        //        {
        //            a.statusCode = NotFound().StatusCode;
        //            a.statusDescription = "RECIPE WITH ID: " + id + ", NOT FOUND. COULD NOT MODIFY";
        //            return a;
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    a.statusCode = NoContent().StatusCode;
        //    a.statusDescription = "RECIPE WITH ID: " + id + ", SUCCESSFULLY MODIFIED";
        //    return a;
        //}
        public async Task<Response> PutRecipe(int id, Recipe recipe)
        {
            Response a = new Response();
            a.statusCode = 401;
            a.statusDescription = "MODIFICATION NOT ALLOWED";
            return a;
        }

        // POST: api/Recipe
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        //{
        //    if (_context.Recipes == null)
        //    {
        //        return Problem("Entity set 'RecipeAPIDBContext.Recipes'  is null.");
        //    }
        //    _context.Recipes.Add(recipe);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetRecipe", new { id = recipe.RecipeID }, recipe);
        //}
        public async Task<Response> PostRecipe(Recipe recipe)
        {
            Response a = new Response();
            if (_context.Recipes == null)
            {
                a.statusCode = NotFound().StatusCode;
                a.statusDescription = "COULD NOT FIND TABLE: RECIPES. COULD NOT ADD NEW RECIPE";
                return a;
            }

            if (RecipeExists(recipe.RecipeID))
            {
                a.statusCode = 409;
                a.statusDescription = "RECIPE WITH ID: " + recipe.RecipeID + ", ALREADY EXISTS";
                return a;
            }

            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            a.statusCode = 201;
            a.statusDescription = "RECIPE: " + recipe.RecipeName + ", SUCCESSFULLY CREATED";
            a.returnList = recipe;

            return a;
        }

        // DELETE: api/Recipe/5
        [HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRecipe(int id)
        //{
        //    if (_context.Recipes == null)
        //    {
        //        return NotFound();
        //    }
        //    var recipe = await _context.Recipes.Include(r => r.Nutrition).FirstOrDefaultAsync(r => r.RecipeID == id);

        //    if (recipe == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Recipes.Remove(recipe);

        //    var nutrition = await _context.Nutrition.FindAsync(recipe.Nutrition!.NutritionID);
        //    _context.Nutrition.Remove(nutrition!);

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
        public async Task<Response> DeleteRecipe(int id)
        {
            Response a = new Response();
            if (_context.Recipes == null)
            {
                a.statusCode = NotFound().StatusCode;
                a.statusDescription = "COULD NOT FIND TABLE: RECIPES. COULD NOT DELETE";
                return a;
            }
            var recipe = await _context.Recipes.Include(r => r.Nutrition).FirstOrDefaultAsync(r => r.RecipeID == id);

            if (recipe == null)
            {
                a.statusCode = NotFound().StatusCode;
                a.statusDescription = "RECIPE WITH ID: " + id + ", NOT FOUND";
                return a;
            }

            _context.Recipes.Remove(recipe);

            var nutrition = await _context.Nutrition.FindAsync(recipe.Nutrition!.NutritionID);
            _context.Nutrition.Remove(nutrition!);

            await _context.SaveChangesAsync();

            a.statusCode = NoContent().StatusCode;
            a.statusDescription = "RECIPE WITH ID: " + id + ", SUCCESSFULLY REMOVED";

            return a;
        }

        private bool RecipeExists(int id)
        {
            return (_context.Recipes?.Any(e => e.RecipeID == id)).GetValueOrDefault();
        }
    }
}
