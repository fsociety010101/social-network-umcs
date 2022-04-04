using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Data;
using SocialNetwork.App.Model.Users;
using SocialNetwork.Data.Model;

namespace SocialNetwork.App.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> Logger;
        private readonly DefaultContext Context;

        public UserController(ILogger<UserController> logger, DefaultContext context)
        {
            Logger = logger;
            Context = context;
        }

        [HttpGet("list")]
        public IEnumerable<User> GetUsers()
        {
            return Context.Users.ToList();
        }

        [HttpGet("test")]
        public string Test()
        {
            return "Test";
        }
    }
}