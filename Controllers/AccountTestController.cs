namespace Group_4_Intake_44.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTestController : ControllerBase
    {
        // Authorization  => Authentication + Some Roles Or Access
        // Authorize(Role Admin) => Admin Role
        // Authorize => Customer Role 


        //1- Authorize Test
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<string>> GetSomething()
        {
            return "You Are Authenticated";
        }

        //2- Authorization Test
        [HttpGet("{id:int}")]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<ActionResult<string>> GetSomething(int someIntValue)
        {
            return "You Are Authorized With Role Of Admin";
        }

    }
}
