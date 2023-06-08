using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelApi.Models;

namespace TravelApi.Controllers.v1
{
  [ApiController] 
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiVersion("1.0")]
  public class ReviewsController : ControllerBase
  {
    private readonly TravelApiContext _db;

    public ReviewsController(TravelApiContext db)
    {
      _db = db;
    }

    // GET api/reviews
    [HttpGet]
    public async Task<List<Review>> Get(string text, int countryId, int userId, string countryName, string userName, bool random = false)
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

      if (userId > 0)
      {
        query = query.Where(entry => entry.UserId == userId);
      }

      if (countryName != null)
      {
        Country thisCountry = await _db.Countries.FirstOrDefaultAsync(c => c.Name == countryName);
        query = query.Where(entry => entry.CountryId == thisCountry.CountryId);
      }

      if (userName != null)
      {
        User thisUser = await _db.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        query = query.Where(entry => entry.UserId == thisUser.UserId);
      }
      if (random)
      {
        Random randomInt = new Random();
        int id = randomInt.Next(1, _db.Reviews.ToList().Count);
        query = query.Where(r => r.ReviewId == id);
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
      Country thisCountry = await _db.Countries
                                        .Include(country => country.Reviews)
                                        .FirstOrDefaultAsync(country => country.CountryId == review.CountryId);
      User thisUser = await _db.Users
                              .Include(user => user.Reviews)
                              .FirstOrDefaultAsync(user => user.UserId == review.UserId);
      if (thisCountry == null)
      {
        return NotFound("this country doesn't exist");
      }
      else if (thisUser == null)
      {
        return NotFound("this user does not exist");
      }
      else
      {
        // review.CountryId = thisCountry.CountryId;
        _db.Reviews.Add(review);
        await _db.SaveChangesAsync();
        thisUser.Reviews.Add(review);
        thisCountry.Reviews.Add(review);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetReview), new { id = review.ReviewId }, review);
      }
    }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> Put(int id, Review review)
    // {
    //   if (id != review.ReviewId)
    //   {
    //     return BadRequest();
    //   }

    //   _db.Reviews.Update(review);

    //   try
    //   {
    //     await _db.SaveChangesAsync();
    //   }
    //   catch (DbUpdateConcurrencyException)
    //   {
    //     if (!ReviewExists(id))
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

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteReview(int id)
    // {
    //   Review review = await _db.Reviews.FindAsync(id);
    //   if (review == null)
    //   {
    //     return NotFound();
    //   }

    //   _db.Reviews.Remove(review);
    //   await _db.SaveChangesAsync();

    //   return NoContent();
    // }

    // private bool ReviewExists(int id)
    // {
    //   return _db.Reviews.Any(e => e.ReviewId == id);
    // }

  }
}