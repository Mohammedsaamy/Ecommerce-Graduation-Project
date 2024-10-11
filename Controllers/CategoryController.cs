namespace Group_4_Intake_44.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly gis44_SupplyChainContext _db;
        private AppResponse _Response;

        public CategoryController(gis44_SupplyChainContext db)
        {
            _db = db;
            _Response = new AppResponse();
        }

        //1- Get All Categories 
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            _Response.Result = _db.Categories;
            _Response.StatusCode = HttpStatusCode.OK;
            return Ok(_Response);
        }

    }
}
