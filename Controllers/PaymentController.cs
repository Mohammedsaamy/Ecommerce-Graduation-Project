namespace Group_4_Intake_44.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly gis44_SupplyChainContext _db;
        protected AppResponse _Response;

        public PaymentController(IConfiguration configuration, gis44_SupplyChainContext db)
        {
            _configuration = configuration;
            _db = db;
            _Response = new AppResponse();
        }

        //1- Create Payment Intent
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<AppResponse>> MakePayment(string userid)
        {
            Shopping_Cart shoppingCart = _db.Shopping_Carts.Include(u => u.Cart_Items)
                .ThenInclude(u => u.Product)
                .FirstOrDefault(u => u.UserID == userid);

            if (shoppingCart == null || shoppingCart.Cart_Items == null || shoppingCart.Cart_Items.Count() == 0)
            {
                _Response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _Response.IsSuccess = false;
                return BadRequest();
            }

            #region Create Payment Intent

            StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];

            shoppingCart.CartTotal = (double)shoppingCart.Cart_Items.Sum(u => u.Quantity * u.Product.Price);

            PaymentIntentCreateOptions options = new()
            {
                Amount = (int)(shoppingCart.CartTotal * 100),
                Currency = "usd",
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                },
            };
            PaymentIntentService service = new();
            PaymentIntent response = service.Create(options);
            shoppingCart.StripPaymentIntenId = response.Id;
            shoppingCart.ClientSecret = response.ClientSecret;

            #endregion

            _Response.Result = shoppingCart;
            _Response.StatusCode = HttpStatusCode.OK;
            return Ok(_Response);
        }

    }
}
