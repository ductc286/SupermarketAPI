using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using Supperket.BLL.IBusiness;
using System.Collections.Generic;

namespace SupermarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndOfShiftController : ControllerBase
    {
        private readonly IEndOfShiftBusiness _endOfShiftBusiness;

        public EndOfShiftController(IEndOfShiftBusiness endOfShiftBusiness)
        {
            _endOfShiftBusiness = endOfShiftBusiness;
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<EndOfShift>> GetAll()
        {
            return _endOfShiftBusiness.GetAll();
        }

        // GET: api/Categories/5
        [HttpPost("{id}")]
        public void Approve(EndOfShift entity)
        {
            _endOfShiftBusiness.Approve(entity); 
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult Put(int id, EndOfShiftViewModel obj)
        {
            if (id != obj.EndOfShiftId)
            {
                return BadRequest();
            }

            _endOfShiftBusiness.Update(obj);

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<EndOfShiftViewModel> Post(EndOfShiftViewModel obj)
        {
            _endOfShiftBusiness.Add(obj);

            return CreatedAtAction("GetById", new { id = obj.EndOfShiftId }, obj);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public ActionResult<EndOfShift> Delete(EndOfShift obj)
        {
            _endOfShiftBusiness.Delete(obj);
            return obj;
        }
    }
}
