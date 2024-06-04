using AutoMapper;
using Entities;
using Entities.DtoUser;
using Microsoft.AspNetCore.Mvc;
using NLog.LayoutRenderers;
using Service;


namespace start.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> logger;
        IUserService userService;
        private readonly IMapper mapper;

        public UsersController(IUserService userService, IMapper mapper, ILogger<UsersController> logger)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.logger = logger;
        }

        // POST: UsersController/Create
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterDto user)
        {

            User newUser = mapper.Map<User>(user);

            User res = await userService.Register(newUser);
            if (res != null)
            {
                logger.LogInformation("register {res.FirstName}");
                return Ok(newUser);
            }
            logger.LogError("register {user.Password}");
            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(LoginDto user)
        {
           
            User newUser = mapper.Map<User>(user);

            User res = await userService.Login(newUser);
            if (res != null)
            {
                logger.LogInformation("login {res.FirstName}");
                return Ok(res);
            }
            logger.LogError("login {user.Password}");
            return Unauthorized(); 

        }


        [HttpPost("password")]
        public  ActionResult<int> password([FromBody]string password)
        {
            int score = userService.CheckPasswordStrength(password);
            return Ok(score);
        

        }
        [HttpPut]
        public async Task<ActionResult<User>> Update([FromBody]UpdateDto user)
        {

            User newUser = mapper.Map<User>(user);

            User res = await userService.Update(newUser);
            if (res != null)
                return Ok(newUser);
            return BadRequest();
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUserById(int userId)
        {

            User res = await userService.GetUserById(userId);
            if (res != null)
                return Ok(res);
            return BadRequest();
        }



    }
}

