using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BL.DTOs;
using BL.Services;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStore_API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase {
	    private OrderService orderService;

	    public OrderController(OrderService orderService) {
		    this.orderService = orderService;
	    }
	    //api/order/5
	    [HttpGet("{id}")]
	    public async Task<IEnumerable<OrderDTO>> GetAllForUser(int id) {
			if(id.ToString() != (this.User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Name)?.Value) {
				return (await orderService.GetAllAsync()).Where(o => o.User.Id == id);
			}
			else {
				throw new Exception("You have no access to this data");
			}
	    }

	    // POST: api/order
	    [HttpPost]
	    public async Task<OrderDTO> CreateOrder([FromBody] OrderDTO order) {
		    return await orderService.PostAsync(order);
	    }
	}
}