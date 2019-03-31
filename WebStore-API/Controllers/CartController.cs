using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BL.DTOs;
using BL.Services;
using DAL;
using DAL.Contexts;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
	    private OrderService orderService;
	    private UserService userService;

	    public CartController(OrderService orderService, UserService userService) {
		    this.orderService = orderService;
		    this.userService = userService;
	    }
	    //api/cart/5
	    [HttpGet("{id}")]
	    public async Task<OrderDTO> GetCartForUser(int id) {
		    if (id.ToString() == (this.User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Name)?.Value) {
			    return (await orderService.GetAllAsync()).FirstOrDefault(o => o.User.Id == id && o.OrderStatus == OrderStatus.Basket);
		    } else {
			    throw new Exception("You have no access to this data");
		    }
	    }

	    // POST: api/cart
	    [HttpPost("{id}")]
	    public async Task<OrderDTO> AddProduct(int id, [FromBody] ProductDTO product) {
		    if (id.ToString() == (this.User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Name)?.Value) {
			    var user = await userService.GetOneAsync(id);
				return await orderService.AddToCart(product, user);
			} else {
			    throw new Exception("You have no access to this data");
		    }
	    }
	}
}