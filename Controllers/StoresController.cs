namespace Group_4_Intake_44.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreRepositry storeRepositry;
        private readonly gis44_SupplyChainContext _db;
        private AppResponse _Response;

        public StoresController(gis44_SupplyChainContext db, IStoreRepositry storeRepositry)
        {
            this.storeRepositry = storeRepositry;
            _db = db;
            _Response = new AppResponse();
        }


        //1- Get All Stores   (Done)
        [HttpGet]
        public async Task<IActionResult> GetAllStores()
        {
            List<Store> stores = storeRepositry.GetAll();
            List<StoreDTO> storeDTOs = stores.Select(stores => new StoreDTO
            {
                ID = stores.ID,
                Name = stores.Name,
                Address = stores.Address,
                Long = stores.Long,
                Lat = stores.Lat,
                MobileNumber = stores.MobileNumber,
                whatsappNumber = stores.whatsappNumber,
                FacebookLink = stores.FacebookLink,
                CarNumbers = stores.CarNumbers,

            }).ToList();

            _Response.Result = storeDTOs;
            _Response.StatusCode = HttpStatusCode.OK;
            return Ok(_Response);
        }


        //2- Get Stores By Id  (Done)
        [HttpGet("Store/{id:int}")]
        public async Task<IActionResult> GetByID(int id)
        {
            Store stores = storeRepositry.GetByID(id);

            if (id == 0)
            {
                _Response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_Response);
            }
            if (stores == null)
            {
                _Response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_Response);
            }
            _Response.Result = stores;
            _Response.StatusCode = HttpStatusCode.OK;
            return Ok(_Response);
        }

        //3- Get Stores By Product IDS Using Query    (Done)
        [HttpGet("StoresByQueryID")]
        public async Task<IActionResult> GetStoresByProductIds([FromQuery] string productIds)
        {
            if (string.IsNullOrEmpty(productIds))
            {
                return BadRequest("Product IDs list is empty.");
            }

            // Split the comma-separated product IDs into a list of integers
            var productIdsList = productIds.Split(',').Select(int.Parse).ToList();

            // Query the database to get the stores that contain all specified products
            var stores = await _db.Stores
                .Where(s => productIdsList.All(pid => s.Store_Products.Any(sp => sp.ProductID == pid)))
                .Select(s => new
                {
                    s.ID,
                    s.Name,
                    s.Address,
                    s.Long,
                    s.Lat,
                    //Products = s.Store_Products
                    //    .Where(sp => productIdsList.Contains((int)sp.ProductID))
                    //    .Select(sp => new
                    //    {
                    //        sp.ProductID,
                    //        sp.Product.Name,
                    //        sp.Product.Description,
                    //        sp.Quantity
                    //    })
                })
                .ToListAsync();

            return Ok(stores);
        }


        //4- Create Store  (Done)
        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<ActionResult<AppResponse>> AddStore([FromForm] CreateStoreDTO createStore)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    Store StoreToCreate = new()
                    {
                        Name = createStore.Name,
                        Address = createStore.Address,
                        Long = createStore.Long,
                        Lat = createStore.Lat,
                        MobileNumber = createStore.MobileNumber,
                        whatsappNumber = createStore.whatsappNumber,
                        FacebookLink = createStore.FacebookLink,
                        CarNumbers = createStore.CarNumbers,

                    };
                    storeRepositry.Insert(StoreToCreate);
                    storeRepositry.Save();
                    _Response.Result = StoreToCreate;
                    _Response.StatusCode = HttpStatusCode.Created;
                    return CreatedAtRoute("GetByID", new { id = StoreToCreate }, _Response);
                }
                else
                {
                    _Response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                _Response.IsSuccess = false;
                _Response.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
            }
            return _Response;
        }


        //5- Update Store   (Done)
        [HttpPut]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<ActionResult<AppResponse>> UpdateStore(int id, [FromForm] UpdateStoreDTO updateStoreDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Store Oldstore = storeRepositry.GetByID(id);
                    if (Oldstore == null)
                    {
                        return BadRequest();
                    }

                    Oldstore.Name = updateStoreDTO.Name;
                    Oldstore.Address = updateStoreDTO.Address;
                    Oldstore.Long = updateStoreDTO.Long;
                    Oldstore.Lat = updateStoreDTO.Lat;
                    Oldstore.MobileNumber = updateStoreDTO.MobileNumber;
                    Oldstore.whatsappNumber = updateStoreDTO.whatsappNumber;
                    Oldstore.FacebookLink = updateStoreDTO.FacebookLink;
                    Oldstore.CarNumbers = updateStoreDTO.CarNumbers;

                    storeRepositry.Update(Oldstore);
                    storeRepositry.Save();
                    _Response.StatusCode = HttpStatusCode.NoContent;
                    return Ok(_Response);
                }
                else
                {
                    _Response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                _Response.IsSuccess = false;
                _Response.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
            }
            return _Response;
        }


        //6- Delete Store (Done)
        [HttpDelete("{id:int}")]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<ActionResult<AppResponse>> DeleteStore(int id)
        {
            try
            {
                Store StoreFromDb = storeRepositry.GetByID(id);
                if (id == 0)
                {
                    return BadRequest();
                }

                if (StoreFromDb == null)
                {
                    return BadRequest();
                }

                storeRepositry.Delete(id);
                storeRepositry.Save();
                _Response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_Response);
            }
            catch (Exception ex)
            {
                _Response.IsSuccess = false;
                _Response.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
            }
            return _Response;
        }

    }
}
