using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            //var locations = _poopyDbContext.PoopLocations.ToList();

            //var locationDto = new List<LocationDto>();
            //foreach (var location in locations)
            //{
            //    locationDto.Add(new LocationDto
            //    {
            //        Id = location.Id,
            //        Latitude = location.Latitude,
            //        Longitude = location.Longitude,
            //        Votes = location.Votes,
            //        PoopDate = location.PoopDate,
            //        //UserId = location.UserId,
            //        //User = location.User
            //    });
            //}

            //if (locationDto.Count == 0)
            //{
            //    return NoContent();
            //}

            //return Ok(locationDto);
            return Ok();
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute]Guid id)
        {
            //var location = _poopyDbContext.PoopLocations.FirstOrDefault(x => x.Id == id);

            //if (location == null)
            //{
            //    return NoContent();
            //};

            //var locationDto = new LocationDto
            //{
            //    Id = location.Id,
            //    Latitude = location.Latitude,
            //    Longitude = location.Longitude,
            //    Votes = location.Votes,
            //    PoopDate = location.PoopDate,
            //    //UserId = location.UserId,
            //    //User = location.User
            //};

            //return Ok(locationDto);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] LocationDto locationDto)
        {
            //Users user = _poopyDbContext.Users.FirstOrDefault(x => x.Uid == locationDto.Uid);
            //var location = new PoopLocations
            //{
            //    Id = new Guid(),
            //    Latitude = locationDto.Latitude,
            //    Longitude = locationDto.Longitude,
            //    Votes = 0,
            //    PoopDate = DateOnly.FromDateTime(DateTime.Now),
            //    UserId = user.Id,
            //};

            //_poopyDbContext.PoopLocations.Add(location);
            //_poopyDbContext.SaveChanges();

            //var locationDtoResponse = new LocationDto
            //{
            //    Id = location.Id,
            //    Latitude = location.Latitude,
            //    Longitude = location.Longitude,
            //    Votes = location.Votes,
            //    PoopDate = location.PoopDate,
            //    //UserId = location.UserId,
            //    //User = location.User
            //};

            return Ok();
            //return CreatedAtAction(nameof(GetById), new { id = locationDtoResponse.Id }, locationDtoResponse);
        }

        
        //[HttpGet]
        //public IActionResult GetAllLocations()
        //{
        //    var location = new List<LocationDto>();

        //    location.Add(new LocationDto()
        //    {
        //        Id = Guid.NewGuid(),
        //        Latitude = 32.0853,
        //        Longitude = 34.7818,
        //        Votes = 0,
        //        PoopDate = new DateOnly(2022, 7, 6),
        //        UserId = Guid.NewGuid(),
        //        User = new Users()
        //        {
        //            Id = Guid.NewGuid(),
        //            PrivateName = "John",
        //            FamilyName = "Doe",
        //            Email = ""
        //        }
        //    });

        //    return Ok();
        //}
    }
}
