using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoopyPoApi.Data;
using PoopyPoApi.Models.Domain;
using PoopyPoApi.Models.Dto;

namespace PoopyPoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly PoopyDbContext _poopyDbContext;

        public PointsController(PoopyDbContext poopyDbContext)
        {
            _poopyDbContext = poopyDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var locations = _poopyDbContext.PoopLocations.Include(o => o.User).ToList();

            var locationDto = new List<LocationDto>();
            foreach (var location in locations)
            {
                locationDto.Add(new LocationDto
                {
                    Id = location.Id,
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    Votes = location.Votes,
                    PoopDate = location.PoopDate,
                    UserId = location.UserId,
                    User = location.User
                });
            }

            if (locationDto.Count == 0)
            {
                return NoContent();
            }

            return Ok(locationDto);
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute]Guid id)
        {
            var location = _poopyDbContext.PoopLocations.FirstOrDefault(x => x.Id == id);

            if (location == null)
            {
                return NoContent();
            };

            var locationDto = new LocationDto
            {
                Id = location.Id,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Votes = location.Votes,
                PoopDate = location.PoopDate,
                User = location.User
            };

            return Ok(locationDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] LocationDto locationDto)
        {
            User user = _poopyDbContext.Users.FirstOrDefault(x => x.Id == locationDto.UserId);
            if(user is null)
            {
                return BadRequest();
            }
            if (_poopyDbContext.PoopLocations.Any(x => x.Latitude == locationDto.Latitude && x.Longitude == locationDto.Longitude))
            { 
                return NoContent();
            }

            var location = new PoopLocation
            {
                Id = new Guid(),
                Latitude = locationDto.Latitude,
                Longitude = locationDto.Longitude,
                Votes = 0,
                PoopDate = DateOnly.FromDateTime(DateTime.Now),
                UserId = user.Id,
                User = user
            };

            _poopyDbContext.PoopLocations.Add(location);
            _poopyDbContext.SaveChanges();

            var locationDtoResponse = new LocationDto
            {
                Id = location.Id,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Votes = location.Votes,
                PoopDate = location.PoopDate,
                UserId = location.UserId,
                User = location.User
                };

            return CreatedAtAction(nameof(GetById), new { id = locationDtoResponse.Id }, locationDtoResponse);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            _poopyDbContext.PoopLocations.ToList();
            _poopyDbContext.PoopLocations.RemoveRange(_poopyDbContext.PoopLocations);
           _poopyDbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("{id:Guid}/{score:int}")]
        public IActionResult UpdateVote([FromRoute]Guid id,[FromRoute] int score)
        {
            var location = _poopyDbContext.PoopLocations.FirstOrDefault(x => x.Id == id);

            if (location == null)
            {
                return NoContent();
            };

            location.Votes = score;
            _poopyDbContext.SaveChanges();

            return Ok(location);
        }
    
    }
}
