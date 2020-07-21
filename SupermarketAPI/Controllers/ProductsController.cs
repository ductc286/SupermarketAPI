using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using Supperket.BLL.IBusiness;
using System.Collections.Generic;

namespace SupermarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductBusiness _productBusiness;

        public ProductsController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return _productBusiness.GetAll();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var obj = _productBusiness.GetById(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProductViewModel obj)
        {
            if (id != obj.ProductId)
            {
                return BadRequest();
            }

            _productBusiness.Update(obj);

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<ProductViewModel> Post(ProductViewModel obj)
        {
            _productBusiness.Add(obj);

            return CreatedAtAction("GetById", new { id = obj.ProductId }, obj);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            var obj = _productBusiness.GetById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _productBusiness.Delete(id);
            return obj;
        }
    }
}
