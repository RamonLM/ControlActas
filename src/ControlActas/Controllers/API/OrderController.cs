using AutoMapper;
using ControlActas.Models;
using ControlActas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlActas.Controllers.API
{
    [Route("api/orders")]
    public class OrderController : Controller
    {
        private ILogger<OrderController> _logger;
        private ILibraryRepository _repository;

        public OrderController(ILibraryRepository repository, ILogger<OrderController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var orders = _repository.GetAllOrders();
                return Ok(Mapper.Map<IEnumerable<OrderViewModel>>(orders));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all orders: {ex}");
                return BadRequest("Error Ocurred");
            }
        }

        [HttpGet("{username}")]
        public IActionResult GetOrdersByRequestor(string username)
        {
            try
            {
                var user = _repository.GetUserByUsername(username);
                var orders = _repository.GetOrdersByRequestor(user);
                return Ok(Mapper.Map<IEnumerable<OrderViewModel>>(orders.OrderBy(o => o.Ordered).ToList()));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error retrieving orders {0}", ex);
            }
            return BadRequest("Failed to get orders");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOrderById(int id)
        {
            try
            {
                var order = _repository.GetOrderById(id);
                return Ok(Mapper.Map<OrderViewModel>(order));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error retrieving orders {0}", ex);
            }
            return BadRequest("Failed to get orders");
        }

        [HttpPost("{username}")]
        public async Task<IActionResult> Post(string username, [FromBody] OrderViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = Mapper.Map<BookOrder>(vm);
                    _repository.AddOrder(username, newOrder);
                    if (await _repository.SaveChangesAsync())
                    {
                        return Created($"api/orders/{username}/{newOrder.Name}", Mapper.Map<OrderViewModel>(newOrder));
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new order {0}", ex);
            }
            return BadRequest("Failed to save new order");
        }
    }
}
