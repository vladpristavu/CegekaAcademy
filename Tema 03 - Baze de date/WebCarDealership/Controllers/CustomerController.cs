using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership.Requests;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public CustomerController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var offers = await _dbContext.Customers.ToListAsync();
            return Ok(offers);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbModel = new Customer
            {
                Name = model.Name,
                Email = model.Email
               
            };

            _dbContext.Customers.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] CustomerDeleteRequestModel model)
        {
            var dbId = _dbContext.Customers.FirstOrDefault(x => x.Id == model.Id);
            
                _dbContext.Customers.Remove(dbId);
                await _dbContext.SaveChangesAsync();
                
            
            return Ok();
        }

           
    }
}
