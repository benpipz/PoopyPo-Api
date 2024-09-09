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
    public class UsersController : ControllerBase
    {
        private readonly PoopyDbContext _poopyDbContext;

        public UsersController(PoopyDbContext poopyDbContext)
        {
            _poopyDbContext = poopyDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _poopyDbContext.Users.ToList();

            if (users.Count == 0)
            {
                return StatusCode(204);
            }

            return Ok(users);
        }

        [HttpGet("{uid}")]
        public async Task<IActionResult> IsUserExists([FromRoute]string uid)
        {
            var user = await _poopyDbContext.Users.FirstOrDefaultAsync(x => x.Uid == uid);

            if (user is null)
            {
                return StatusCode(204);
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] SignUpUsersDto singUpUserDto)
        {
            UsersDto userDto = new UsersDto();
            if (userDto is not null)
            {
                Users user = new Users();
                user.SignupDate = DateOnly.FromDateTime(DateTime.Now);
                user.PrivateName = singUpUserDto.Name;
                user.FamilyName = singUpUserDto.Name;
                user.Email = singUpUserDto.Email;
                user.PoopyScore = 0;
                user.Uid = singUpUserDto.Uid;

                _poopyDbContext.Users.Add(user);
                _poopyDbContext.SaveChanges();
            }

            return Ok();
        }


    }
}
