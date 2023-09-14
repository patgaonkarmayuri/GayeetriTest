using Application.Interface;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAPI3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        // GET: api/<OfferController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OfferController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OfferController>
        [HttpPost]
        public async Task<ProcessResponse<bool>> Post(Offer offer)
        {
            ProcessResponse<bool> processResponse= new ProcessResponse<bool>();
            try
            {
                var resp = await _offerService.Create(offer);
                if (processResponse.Success)
                {
                    processResponse.Data = true;
                }
                else
                {
                    processResponse.Data = false;
                    processResponse.Error = processResponse.Error;
                }
            }
            catch (Exception ex)
            {
                processResponse.Success = false;
                processResponse.Error = ex.Message;
            }

            return processResponse;
        }

        // PUT api/<OfferController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OfferController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
