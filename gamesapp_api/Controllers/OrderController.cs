using gamesapp_api.Data;
using gamesapp_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamesapp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderDbContext _dbcontext;
        public OrderController(OrderDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet("GetOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return await _dbcontext.order.ToListAsync();
        }

        [HttpPost("CreateOrder")]
        public IActionResult Create(Order request)
        {
            //Order order = new Order();
            //order.Name = request.Name;
            //order.Products = request.Products;

            _dbcontext.order.Add(request);
            _dbcontext.SaveChanges();

            var orders = _dbcontext.order.ToList();
            return Ok(orders);
        }

        [HttpPut("UpdateOrder")]
        public async Task<ActionResult<IEnumerable<Order>>> Update([FromBody] OrderRequest request)
        {
            var order = _dbcontext.order.FirstOrDefault(x => x.ID == request.ID);
            order.Name = request.Name;
            order.Product1 = request.Product1;
            order.Product2 = request.Product2;
            order.Product3 = request.Product3;
            order.Product4 = request.Product4;
            order.Product5 = request.Product5;

            _dbcontext.Entry(order).State = EntityState.Modified;
            _dbcontext.SaveChanges();

            return await _dbcontext.order.ToListAsync();
        }

        [HttpDelete("DeleteOrder/{Id}")]
        public async Task<ActionResult<IEnumerable<Order>>> Delete([FromRoute] int Id)
        {
            var order = _dbcontext.order.FirstOrDefault(x => x.ID == Id);
            _dbcontext.Entry(order).State = EntityState.Deleted;
            _dbcontext.SaveChanges();

            return await _dbcontext.order.ToListAsync();
        }
    }
}
