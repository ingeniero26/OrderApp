using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderApp.Backend.Data;
using OrderApp.Shared.Entities;

namespace OrderApp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchesTypeController : ControllerBase
    {
        private readonly DataContext _context;
        public BranchesTypeController(DataContext context)
        {
            _context = context;
        }
        // GET: api/BranchesType
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.BranchTypes.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var branchType = await _context.BranchTypes.FirstOrDefaultAsync(b => b.Id == id);
            if (branchType == null)
            {
                return NotFound();
            }
            return Ok(branchType);
        }
        // crear
        [HttpPost]
        public async Task<IActionResult> PostAsync(BranchType branchType)
        {
            _context.Add(branchType);
            await _context.SaveChangesAsync();
            return Ok(branchType);
        }
        // editar
        [HttpPut]
        public async Task<IActionResult> PutAsync(BranchType branchType)
        {
            _context.Update(branchType);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        //eliminar
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var branchType = await _context.BranchTypes.FirstOrDefaultAsync(b => b.Id == id);
            if (branchType == null)
            {
                return NotFound();
            }
            _context.Remove(branchType);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
