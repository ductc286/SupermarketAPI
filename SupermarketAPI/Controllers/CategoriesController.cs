using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using SupermarketAPI.DAL.Database;
using Supperket.BLL.IBusiness;
using System.Collections.Generic;
using System.Linq;
namespace SupermarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly ICategoryBusiness _categoryBusiness;

        public CategoriesController(MyDBContext context, ICategoryBusiness categoryBusiness)
        {
            _context = context;
            _categoryBusiness = categoryBusiness;
        }

        // GET: api/Categories
        //[Microsoft.AspNetCore.Authorization.Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAll()
        {

            return _categoryBusiness.GetAll();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<Category> GetById(int id)
        {
            var category = _categoryBusiness.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult Put(int id, CategoryViewModel category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            _categoryBusiness.Update(category);

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Category> Post(CategoryViewModel category)
        {
            _categoryBusiness.Add(category);

            return CreatedAtAction("GetById", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public ActionResult<Category> DeleteCategory(int id)
        {
            //var category = await _context.Categories.FindAsync(id);
            var category = _categoryBusiness.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryBusiness.Delete(id);
            return category;
        }

        private bool CategoryExists(int id)
        {
            return _categoryBusiness.GetById(id) != null;
        }
    }
}
