using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.Contants;
using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using Supperket.BLL.IBusiness;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierBusiness _supplierBusiness;

        public SuppliersController(ISupplierBusiness supplierBusiness)
        {
            _supplierBusiness = supplierBusiness;
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<Supplier>> GetAll()
        {
            return _supplierBusiness.GetAll();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<Supplier> GetById(int id)
        {
            var obj = _supplierBusiness.GetById(id);

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
        public IActionResult PutCategory(int id, SupplierViewModel supplier)
        {
            if (id != supplier.SupplierId)
            {
                return BadRequest();
            }

            _supplierBusiness.Update(supplier);

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Supplier> PostCategory(SupplierViewModel supplier)
        {
            _supplierBusiness.Add(supplier);

            return CreatedAtAction("GetById", new { id = supplier.SupplierId }, supplier);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public ActionResult<Supplier> DeleteCategory(int id)
        {
            var supplier = _supplierBusiness.GetById(id);
            if (supplier == null)
            {
                return NotFound();
            }
            _supplierBusiness.Delete(id);
            return supplier;
        }
    }
}
