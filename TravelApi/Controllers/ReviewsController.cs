using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelApi.Models;

namespace TravelApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private readonly TravelApiContext _db;

    public ReviewsController(TravelApiContext db)
    {
      _db = db;
    }

    // GET api/reviews
    [HttpGet]
    public async Task<List<Review>> Get(string text, int countryId)
    {
      IQueryable<Review> query = _db.Reviews.AsQueryable();

      if (text != null)
      {
        query = query.Where(entry => entry.Text == text);
      }

      if (countryId > 0)
      {
        query = query.Where(entry => entry.CountryId == countryId);
      }

      return await query.ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetReview(int id)
    {
      Review review = await _db.Reviews.FindAsync(id);

      if (review == null)
      {
        return NotFound();
      }

      return review;
    }

    [HttpPost]
    public async Task<ActionResult<Review>> Post([FromBody] Review review)
    {
      #nullable enable
      Country thisCountry = await _db.Countries
                                        .Include(country => country.Reviews)
                                        .FirstOrDefaultAsync(country => country.CountryId == review.CountryId);
      #nullable disable
      if (thisCountry == null)
      {
        return NotFound("this country doesn't exist");
      }
      else
      {
        review.CountryId = thisCountry.CountryId;
        _db.Reviews.Add(review);
        await _db.SaveChangesAsync();
        thisCountry.Reviews.Add(review);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetReview), new { id = review.ReviewId }, review);
      }
    }

    // // PUT: api/Countries/7
    // [HttpPut("{id}")]
    // public async Task<IActionResult> Put(int id, Country country)
    // {
    //   if (id != country.CountryId)
    //   {
    //     return BadRequest();
    //   }

    //   _db.Countries.Update(country);

    //   try
    //   {
    //     await _db.SaveChangesAsync();
    //   }
    //   catch (DbUpdateConcurrencyException)
    //   {
    //     if (!CountryExists(id))
    //     {
    //       return NotFound();
    //     }
    //     else
    //     {
    //       throw;
    //     }
    //   }

    //   return NoContent();
    // }

    // // DELETE: api/Countries/7
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteCountry(int id)
    // {
    //   Country country = await _db.Countries.FindAsync(id);
    //   if (country == null)
    //   {
    //     return NotFound();
    //   }

    //   _db.Countries.Remove(country);
    //   await _db.SaveChangesAsync();

    //   return NoContent();
    // }

    // private bool CountryExists(int id)
    // {
    //   return _db.Countries.Any(e => e.CountryId == id);
    // }

  }
}