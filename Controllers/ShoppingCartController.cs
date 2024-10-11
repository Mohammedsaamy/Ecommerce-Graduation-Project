namespace Group_4_Intake_44.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly gis44_SupplyChainContext _db;
        private AppResponse _Response;
        public ShoppingCartController(gis44_SupplyChainContext db)
        {
            _db = db;
            _Response = new AppResponse();
        }

        //1-Get Cart Items
        [HttpGet]
        public async Task<ActionResult<AppResponse>> GetShoppingCart(string userid)
        {
            try
            {
                Shopping_Cart shoppingCart;
                if (string.IsNullOrEmpty(userid))
                {
                    shoppingCart = new();
                }
                else
                {
                    shoppingCart = _db.Shopping_Carts.Include(u => u.Cart_Items)
                        .ThenInclude(u => u.Product)
                        .FirstOrDefault(u => u.UserID == userid);
                }

                if (shoppingCart.Cart_Items != null && shoppingCart.Cart_Items.Count > 0)
                {
                    shoppingCart.CartTotal = (double)shoppingCart.Cart_Items.Sum(u => u.Quantity * u.Product.Price);
                }

                _Response.Result = shoppingCart;
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

        //2- Add Product To Cart
        [HttpPost]
        // One Methood For All 
        public async Task<ActionResult<AppResponse>> AddOrUpdateItemInCart(string userid, int productItemId, int updateQuantityBy)
        {
            // -------------- Business Model --------------
            // Shopping cart will have one entry per user id, even if a user has many items in cart.
            // Cart items will have all the items in shopping cart for a user
            // updatequantityby will have count by with an items quantity needs to be updated
            // if it is -1 that means we have lower a count if it is 5 it means we have to add 5 count to existing count.
            // if updatequantityby by is 0, item will be removed

            // -------------- Scenarios --------------
            // 1- when a user adds a new item to a new shopping cart for the first time
            // 2- when a user adds a new item to an existing shopping cart (basically user has other items in cart)
            // 3- when a user updates an existing item count
            // 4- when a user removes an existing item

            Shopping_Cart shoppingCart = _db.Shopping_Carts.Include(u => u.Cart_Items).FirstOrDefault(u => u.UserID == userid);
            Product product = _db.Products.FirstOrDefault(u => u.ID == productItemId);

            // First Scenario
            if (product == null)
            {
                _Response.StatusCode = HttpStatusCode.BadRequest;
                _Response.IsSuccess = false;
                return BadRequest();
            }
            if (shoppingCart == null && updateQuantityBy > 0)
            {
                //Create Shopping Cart 
                Shopping_Cart newCart = new()
                {
                    UserID = userid,
                };
                _db.Shopping_Carts.Add(newCart);
                _db.SaveChanges();

                //Create Cart Items 
                Cart_Item newCartItems = new()
                {
                    ProductID = productItemId,
                    Quantity = updateQuantityBy,
                    ShoppingCartID = newCart.ID,  //From The Last Function
                    //if it wasn't null during the initial insertion, an error would occur //
                    //as it would attempt to generate a product from the beginning //
                    //without all necessary data so we put it null.
                    Product = null
                };
                _db.Cart_Items.Add(newCartItems);
                _db.SaveChanges();
            }

            // Second Scenario
            else
            {
                //Shopping Cart Is Already Exists
                Cart_Item cartItemInCart = shoppingCart.Cart_Items.FirstOrDefault(u => u.ProductID == productItemId);

                if (cartItemInCart == null)
                {
                    //Items Does not Exist In Current Cart 
                    Cart_Item newCartItems = new()
                    {
                        ProductID = productItemId,
                        Quantity = updateQuantityBy,
                        ShoppingCartID = shoppingCart.ID,
                        Product = null
                    };
                    _db.Cart_Items.Add(newCartItems);
                    _db.SaveChanges();
                }
                else
                {
                    //Items Is Already Exists In The Cart And We Have To Update Quantity
                    int newQuantity = cartItemInCart.Quantity + updateQuantityBy;
                    if (updateQuantityBy == 0 || newQuantity <= 0)
                    {
                        //Remove Cart Item From Cart If this The only Ites Then Remove Cart
                        _db.Cart_Items.Remove(cartItemInCart);

                        if (shoppingCart.Cart_Items.Count() == 1)
                        {
                            _db.Cart_Items.Remove(cartItemInCart);
                        }
                        _db.SaveChanges();
                    }
                    else
                    {
                        cartItemInCart.Quantity = newQuantity;
                        _db.SaveChanges();
                    }
                }
            }
            return _Response;
        }

    }
}
