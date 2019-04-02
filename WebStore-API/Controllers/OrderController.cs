using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BL.DTOs;
using BL.Services;
using DAL;
using DAL.Contexts;
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
	    [HttpGet("{userId}")]
	    public async Task<List<OrderDTO>> GetAllForUser(int userId) {
			if(userId.ToString() == (this.User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Name)?.Value) {
				var orders = (await orderService.GetAllAsync(userId));
				return orders.ToList();
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

	    [HttpPost("{userId}")]
	    public async Task<OrderDTO> TransferItemsFromCartToOrder(int userId) {
		    var order =  await orderService.TransferItemsFromCartToOrder(userId);
		    return order;
	    }
	}
}