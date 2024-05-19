using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]    
    [Route("Api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext dataContext;

        public UserController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var Users = await dataContext.AppUsers.ToListAsync();
            if(Users!=null)
            {                
                return Users;
            }
            return BadRequest("no users have been found");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            if(id!=0)
            {
                var user = await dataContext.AppUsers.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(user);
            }
            else
                return BadRequest("User Not Found");
            
        }
    }
}
