namespace Group_4_Intake_44.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private AppResponse _Response;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            _Response = new AppResponse();

        }


        //1- Get All Product  (Done)
        [HttpGet]
        public async Task<IActionResult> GetAllProductItems()
        {
            List<Product> products = productRepository.GetAll();
            List<ProductDTO> productsDTO = products.Select(products => new ProductDTO
            {
                ID = products.ID,
                Name = products.Name,
                CategoryID = products.CategoryID,
                BrandID = products.BrandID,
                Description = products.Description,
                SpecialTag = products.SpecialTag,
                Price = products.Price,
                Image = products.Image,
                Quantity = products.Quantity,

            }).ToList();

            _Response.Result = productsDTO;
            _Response.StatusCode = HttpStatusCode.OK;
            return Ok(_Response);

        }


        //2- Get Product By Id  (Done)
        [HttpGet("product/{id:int}")]
        public async Task<IActionResult> GetByID(int id)
        {
            Product product = productRepository.GetByID(id);

            if (id == 0)
            {
                _Response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_Response);
            }
            if (product == null)
            {
                _Response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_Response);
            }
            _Response.Result = product;
            _Response.StatusCode = HttpStatusCode.OK;
            return Ok(_Response);
        }


        //3- Get Product By CategoryID  (Done)
        [HttpGet("Category/{categoryId:int}")]
         public async Task<IActionResult> GetProductByCategoryID(int categoryId)
        {
            List<Product> products = productRepository.GetByCategoryID(categoryId);

            if (categoryId <= 0)
            {
                _Response.StatusCode = HttpStatusCode.BadRequest;
                 return BadRequest(_Response);
            }

            if (products == null )
            {
                _Response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_Response);            
            }

              _Response.Result = products;
              _Response.StatusCode = HttpStatusCode.OK;
              return Ok(_Response);
         }


        //4- Create Product  (Done)
        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<ActionResult<AppResponse>> AddProduct([FromForm] CreateProductDTO createProduct)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    Product productToCreate = new()
                    {
                        Name = createProduct.Name,
                        CategoryID = createProduct.CategoryID,
                        BrandID = createProduct.BrandID,
                        Description = createProduct.Description,
                        SpecialTag = createProduct.SpecialTag,
                        Price = createProduct.Price,
                        Image = createProduct.Image,
                        Quantity = createProduct.Quantity,

                    };
                    productRepository.Insert(productToCreate);
                    productRepository.Save();
                    _Response.Result = productToCreate;
                    _Response.StatusCode = HttpStatusCode.Created;
                    return CreatedAtRoute("GetByID", new { id = productToCreate }, _Response);
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


        //5- Update Product   (Done)
        [HttpPut]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<ActionResult<AppResponse>> UpdateProduct(int id, [FromForm] UpdateProductDTO updateProductDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Product Oldproduct = productRepository.GetByID(id);
                    if (Oldproduct == null)
                    {
                        return BadRequest();
                    }

                    Oldproduct.Name = updateProductDTO.Name;
                    Oldproduct.CategoryID = updateProductDTO.CategoryID;
                    Oldproduct.BrandID = updateProductDTO.BrandID;
                    Oldproduct.Description = updateProductDTO.Description;
                    Oldproduct.SpecialTag = updateProductDTO.SpecialTag;
                    Oldproduct.Price = updateProductDTO.Price;
                    Oldproduct.Image = updateProductDTO.Image;
                    Oldproduct.Quantity= updateProductDTO.Quantity;

                    productRepository.Update(Oldproduct);
                    productRepository.Save();
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
    

        //6- Delete Product (Done)
        [HttpDelete("{id:int}")]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<ActionResult<AppResponse>> DeleteProduct(int id)
        {
            try
            {
                Product productFromDb = productRepository.GetByID(id);
                if (id == 0)
                {
                    return BadRequest();
                }

                if (productFromDb == null)
                {
                    return BadRequest();
                }

                //int millisecod = 2000;
                //Thread.Sleep(millisecod);

                productRepository.Delete(id);
                productRepository.Save();
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
