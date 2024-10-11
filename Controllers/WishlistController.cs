namespace Group_4_Intake_44.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly gis44_SupplyChainContext _db;
        private AppResponse _Response;
        public WishlistController(gis44_SupplyChainContext db)
        {
            _db = db;
            _Response = new AppResponse();
        }


        //1-Get Wishlist Items
        [HttpGet]
        public async Task<ActionResult<AppResponse>> GetWishListItems(string userid)
        {
            try
            {
                Wishlist wishlist;
                if (string.IsNullOrEmpty(userid))
                {
                    wishlist = new();
                }
                else
                {
                    wishlist = _db.WishLists.Include(u => u.WishListItems)
                        .ThenInclude(u => u.Product)
                        .FirstOrDefault(u => u.UserID == userid);
                }

                _Response.Result = wishlist;
                _Response.IsSuccess = true;
                _Response.StatusCode = HttpStatusCode.OK;
                return Ok(_Response);
            }
            catch (Exception ex)
            {
                _Response.IsSuccess = false;
                _Response.ErrorMessages = new List<string>() { ex.ToString() };
                _Response.StatusCode = HttpStatusCode.BadRequest;
            }

            return _Response;
        }


        //2- Add Product To Wishlist
        [HttpPost]
        public async Task<ActionResult<AppResponse>> AddOrUpdateWishlist(string userid, int productItemId)
        {
            Wishlist wishlist = _db.WishLists.Include(u => u.WishListItems).FirstOrDefault(u => u.UserID == userid);
            Product product = _db.Products.FirstOrDefault(u => u.ID == productItemId);

            // First Scenario
            if (product == null)
            {
                _Response.StatusCode = HttpStatusCode.BadRequest;
                _Response.IsSuccess = false;
                return BadRequest();
            }
            if (wishlist == null )
            {
                //Create Wishlist  
                Wishlist newwishlist = new()
                {
                    UserID = userid,
                };
                _db.WishLists.Add(newwishlist);
                _db.SaveChanges();

                //Create Wishlist Items
                WishlistItems newwishlistItems = new()
                {
                    ProductId= productItemId,
                    WishListID = newwishlist.WishListID, 
                    Product = null
                };
                _db.WishLists.Add(newwishlist);
                _db.SaveChanges();
            }

            return _Response;
        }

    }
}
