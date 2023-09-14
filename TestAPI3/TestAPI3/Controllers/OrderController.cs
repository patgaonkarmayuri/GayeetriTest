using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Shared;
using TestAPI3.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAPI3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _orderService;

        public OrderController(IOrder order)
        {
            _orderService = order;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ProcessResponse<bool>> Post(OrderViewModel order)
        {
            ProcessResponse<bool> processResponse = new ProcessResponse<bool>();
            try
            {
               var resp = await _orderService.Create(new Infrastructure.Models.Order()
                {
                    Amount = order.Amount,
                       CustomerId = order.CustomerId,
                       OrderDate = DateTime.Now
                }, order.OfferId);

                if(resp != null && resp.Success)
                {
                    processResponse.Data = true;
                }
                else
                {
                    processResponse.Data = false;
                }
            }
            catch (Exception ex)
            {
                processResponse.Success = false;
                processResponse.Error = ex.Message;
            }

            return processResponse;
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
