using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using Supperket.BLL.IBusiness;
using System.Collections.Generic;

namespace SupermarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseBillController : ControllerBase
    {
        private readonly IPurchaseBillBusiness _purchaseBillBusiness;

        public PurchaseBillController(IPurchaseBillBusiness purchaseBillBusiness)
        {
            _purchaseBillBusiness = purchaseBillBusiness;
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<List<PurchaseBill>> GetAll()
        {
            return _purchaseBillBusiness.GetAll();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<PurchaseBill> GetById(int id)
        {
            var obj = _purchaseBillBusiness.GetById(id);

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
        public IActionResult Put(string id, PurchaseBillViewModel obj)
        {
            if (id != obj.PurchaseBillId)
            {
                return BadRequest();
            }

            _purchaseBillBusiness.Update(obj);

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<PurchaseBillViewModel> Post(PurchaseBillViewModel obj)
        {
            _purchaseBillBusiness.Add(obj);

            return CreatedAtAction("GetById", new { id = obj.PurchaseBillId }, obj);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public ActionResult<PurchaseBill> Delete(string id)
        {
            var obj = _purchaseBillBusiness.GetById(id);
            if (obj == null)
            {
                return NotFound();
            }

            _purchaseBillBusiness.Delete(obj);
            return obj;
        }
    }
}
