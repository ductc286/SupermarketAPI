using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using Supperket.BLL.IBusiness;

namespace SupermarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleBillController : ControllerBase
    {
        private readonly ISaleBillBusiness _saleBillBusiness;

        public SaleBillController(ISaleBillBusiness saleBillBusiness)
        {
            _saleBillBusiness = saleBillBusiness;
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<List<SaleBill>> GetAll()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var staffRole = claimsIdentity.FindFirst(ClaimTypes.Role)?.Value;
            int staffId;
            int.TryParse(claimsIdentity.FindFirst(ClaimTypes.SerialNumber)?.Value, out staffId);
            return _saleBillBusiness.GetAll(staffRole, staffId);
            
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<SaleBill> GetById(int id)
        {
            var obj = _saleBillBusiness.GetById(id);

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
        public IActionResult Put(string id, SaleBillViewModel obj)
        {
            if (id != obj.SaleBillId)
            {
                return BadRequest();
            }

            _saleBillBusiness.Update(obj);

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<SaleBillViewModel> Post(SaleBillViewModel obj)
        {
            _saleBillBusiness.Add(obj);

            return CreatedAtAction("GetCategory", new { id = obj.SaleBillId }, obj);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public ActionResult<SaleBill> Delete(string id)
        {
            var obj = _saleBillBusiness.GetById(id);
            if (obj == null)
            {
                return NotFound();
            }

            _saleBillBusiness.Delete(obj);
            return obj;
        }
    }
}
