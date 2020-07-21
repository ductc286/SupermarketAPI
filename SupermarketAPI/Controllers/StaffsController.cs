using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using Supperket.BLL.IBusiness;
using System.Collections.Generic;

namespace SupermarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IStaffBusiness _staffBusiness;

        public StaffsController(IStaffBusiness staffBusiness)
        {
            _staffBusiness = staffBusiness;
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<Staff>> GetAll()
        {
            return _staffBusiness.GetAll();
        }

        // GET: api/Categories/5
        //[HttpGet("{id}")]
        //public ActionResult<Product> GetById(int id)
        //{
        //    var obj = _staffBusiness.GetById(id);

        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    return obj;
        //}

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult Put(int id, StaffViewModel obj)
        {
            if (id != obj.StaffId)
            {
                return BadRequest();
            }

            _staffBusiness.Update(obj);

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<StaffViewModel> Post(StaffViewModel obj)
        {
            _staffBusiness.Add(obj);

            return CreatedAtAction("GetById", new { id = obj.StaffId }, obj);
        }

        [HttpPost("ChangePassword")]
        public ActionResult<bool> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            return _staffBusiness.ChangePassword(changePasswordViewModel);
        }
    }
}
