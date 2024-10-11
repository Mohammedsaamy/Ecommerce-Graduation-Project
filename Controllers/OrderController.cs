namespace Group_4_Intake_44.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly gis44_SupplyChainContext _db;
        private AppResponse _Response;
        public OrderController(gis44_SupplyChainContext db)
        {
            _db = db;
            _Response = new AppResponse();
        }


        //1- Get All Orders By User Id
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<AppResponse>> GetOrders(String? userId)
        {
            try
            {
                var OrderHeader = _db.OrderHeaders.Include(u => u.Order_Items).ThenInclude(u => u.Product).OrderByDescending(u => u.ID);
                if (!string.IsNullOrEmpty(userId))
                {
                    _Response.Result = OrderHeader.Where(u => u.ApplicationUserId == userId);
                }
                else
                {
                    _Response.Result = OrderHeader;
                }
                _Response.StatusCode = HttpStatusCode.OK;
                return Ok(_Response);
            }
            catch (Exception ex)
            {
                _Response.IsSuccess = false;
                _Response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _Response;
        }

        //2- Get Orders By Ordder Id
        [HttpGet("{id:int}")]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<ActionResult<AppResponse>> GetOrders(int id)
        {
            try
            {
                if (id == 0)
                {
                    _Response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_Response);
                }

                var OrderHeader = _db.OrderHeaders.Include(u => u.Order_Items).ThenInclude(u => u.Product).Where(u => u.ID == id);
                if (OrderHeader == null)
                {
                    _Response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_Response);
                }

                _Response.Result = OrderHeader;
                _Response.StatusCode = HttpStatusCode.OK;
                return Ok(_Response);
            }
            catch (Exception ex)
            {
                _Response.IsSuccess = false;
                _Response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _Response;
        }

        //3- Get Orders By Store Id
        [HttpGet("Store/{StoreId:int}")]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<ActionResult<AppResponse>> GetOrdersByStore(int StoreId)
        {
            try
            {
                if (StoreId == 0)
                {
                    _Response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_Response);
                }

                var OrderHeader = _db.OrderHeaders.Include(u => u.Order_Items).ThenInclude(u => u.Product).Where(u => u.StoreID == StoreId);
                if (OrderHeader == null)
                {
                    _Response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_Response);
                }

                _Response.Result = OrderHeader;
                _Response.StatusCode = HttpStatusCode.OK;
                return Ok(_Response);
            }
            catch (Exception ex)
            {
                _Response.IsSuccess = false;
                _Response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _Response;
        }

        //4- Create Order 
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<AppResponse>> CreateOrder([FromBody] OrderHeaderCreateDTO orderHeaderDTO)
        {
            try
            {
                OrderHeader order = new()
                {
                    ApplicationUserId = orderHeaderDTO.ApplicationUserId,
                    PickupEmail = orderHeaderDTO.PickupEmail,
                    PickupName = orderHeaderDTO.PickupName,
                    PickupPhone = orderHeaderDTO.PickupPhone,
                    OrderTotal = orderHeaderDTO.OrderTotal,
                    OrderDate = DateTime.Now,
                    StripePaymentIntelID = orderHeaderDTO.StripePaymentIntentID,
                    TotalItems = orderHeaderDTO.TotalItems,
                    Status = String.IsNullOrEmpty(orderHeaderDTO.Status) ? SD.status_pending : orderHeaderDTO.Status,
                };

                if (ModelState.IsValid)
                {
                    _db.OrderHeaders.Add(order);
                    _db.SaveChanges();
                    foreach (var orderDetailDTO in orderHeaderDTO.OrderDetailsDTO)
                    {
                        Order_Item orderItem = new()
                        {
                            OrederHearderID = order.ID,
                            ProductName = orderDetailDTO.ProductName,
                            ProductID = orderDetailDTO.ProductId,
                            Price = orderDetailDTO.Price,
                            Quantity = orderDetailDTO.Quantity,
                        };
                        _db.Order_Items.Add(orderItem);
                    }
                    _db.SaveChanges();
                    _Response.Result = true;
                    order.Order_Items = null;
                    _Response.StatusCode = HttpStatusCode.Created;
                    return Ok(_Response);
                }
            }
            catch (Exception ex)
            {
                _Response.IsSuccess = false;
                _Response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _Response;
        }

        //5- Update Order By order Id 
        [HttpPut("{id:int}")]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<ActionResult<AppResponse>> UpdateOrderHeader(int id, [FromBody] OrderHeaderUpdateDTO orderHeaderUpdateDTO)
        {
            try
            {
                if (orderHeaderUpdateDTO == null || id != orderHeaderUpdateDTO.OrderHeaderId)
                {
                    _Response.IsSuccess = false;
                    _Response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                OrderHeader OrderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.ID == id);

                if (OrderFromDb == null)
                {
                    _Response.IsSuccess = false;
                    _Response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }

                if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.PickupName))
                {
                    OrderFromDb.PickupName = orderHeaderUpdateDTO.PickupName;
                }

                if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.PickupPhone))
                {
                    OrderFromDb.PickupPhone = orderHeaderUpdateDTO.PickupPhone;
                }

                if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.PickupEmail))
                {
                    OrderFromDb.PickupEmail = orderHeaderUpdateDTO.PickupEmail;
                }

                if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.Status))
                {
                    OrderFromDb.Status = orderHeaderUpdateDTO.Status;
                }

                if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.StripePaymentIntentID))
                {
                    OrderFromDb.StripePaymentIntelID = orderHeaderUpdateDTO.StripePaymentIntentID;
                }

                _db.SaveChanges();
                _Response.StatusCode = HttpStatusCode.NoContent;
                _Response.IsSuccess = true;
                return Ok(_Response);
            }
            catch (Exception ex)
            {
                _Response.IsSuccess = false;
                _Response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _Response;
        }

        //6- Get All Orders
        [HttpGet("All")]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<ActionResult<AppResponse>> GetAllOrders()
        {
            try
            {
                var orderHeaders = await _db.OrderHeaders.Include(u => u.Order_Items).ThenInclude(u => u.Product).ToListAsync();
                if (orderHeaders == null || orderHeaders.Count == 0)
                {
                    _Response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_Response);
                }

                _Response.Result = orderHeaders;
                _Response.StatusCode = HttpStatusCode.OK;
                return Ok(_Response);
            }
            catch (Exception ex)
            {
                _Response.IsSuccess = false;
                _Response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _Response;
        }



    }
}
