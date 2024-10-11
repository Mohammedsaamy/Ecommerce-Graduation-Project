namespace Group_4_Intake_44.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly gis44_SupplyChainContext _db;
        private AppResponse _Response;
        private string SecretKey;

        public AccountController(gis44_SupplyChainContext db,
               UserManager<ApplicationUser> userManager,
               RoleManager<IdentityRole> roleManager,
               IConfiguration configuration)
        {
            _db = db;
            SecretKey = configuration.GetValue<string>("ApiSetting:Secret");
            _Response = new AppResponse();
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //1-Registration   (Done)
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDTO model)
        {
            ApplicationUser userFromDb = _db.ApplicationUsers
                .FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());

            if (userFromDb != null)
            {
                _Response.StatusCode = HttpStatusCode.BadRequest;
                _Response.IsSuccess = false;
                _Response.ErrorMessages.Add("Username already exists");
                return BadRequest(_Response);
            }

            ApplicationUser newUser = new()
            {
                UserName = model.UserName,
                Email = model.UserName,
                NormalizedEmail = model.UserName.ToUpper(),
                Name = model.Name,
                Address = model.Address,
                MobileNumber = model.MobileNumber
            };

            try
            {
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
                    {
                        //create roles in database
                        await _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
                        await _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer));
                    }
                    if (model.Role.ToLower() == SD.Role_Admin)
                    {
                        await _userManager.AddToRoleAsync(newUser, SD.Role_Admin);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(newUser, SD.Role_Customer);
                    }

                    _Response.StatusCode = HttpStatusCode.OK;
                    _Response.IsSuccess = true;
                    return Ok(_Response);
                }
            }
            catch (Exception)
            {
                
            }

            _Response.StatusCode = HttpStatusCode.BadRequest;
            _Response.IsSuccess = false;
            _Response.ErrorMessages.Add("Error while registering");
            return BadRequest(_Response);
        }



        //2-Login        (Done)
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTOcs model)
        {
            ApplicationUser userFromdb = _db.ApplicationUsers
                .FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());

            if (userFromdb == null)
            {
                _Response.Result = new LoginResponseDTO();
                _Response.StatusCode = HttpStatusCode.BadRequest;
                _Response.IsSuccess = false;
                _Response.ErrorMessages.Add("Username Or Password Is Incorrect");
                return BadRequest(_Response);
            }

            bool isValid = await _userManager.CheckPasswordAsync(userFromdb, model.Password);

            if (!isValid)
            {
                _Response.Result = new LoginResponseDTO();
                _Response.StatusCode = HttpStatusCode.BadRequest;
                _Response.IsSuccess = false;
                _Response.ErrorMessages.Add("Username Or Password Is Incorrect");
                return BadRequest(_Response);
            }

            // Generate JWT Token
            var roles = await _userManager.GetRolesAsync(userFromdb);
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.UTF8.GetBytes(SecretKey);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                      new Claim("FullName", userFromdb.Name),
                      new Claim("ID", userFromdb.Id.ToString()),
                      new Claim(ClaimTypes.Email, userFromdb.UserName.ToString()),
                      new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponseDTO loginResponse = new()
            {
                Email = userFromdb.Email,
                Token = tokenHandler.WriteToken(token),
            };

            _Response.StatusCode = HttpStatusCode.OK;
            _Response.IsSuccess = true;
            _Response.Result = loginResponse;
            return Ok(_Response); // Return Ok for successful login
        }

    }
}
