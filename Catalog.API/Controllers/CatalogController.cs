using Catalog.API.Models;
using Catalog.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogRepository _catalogRepository;
        public CatalogController(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }
        // GET: api/<CatalogController>
        [HttpGet]
        public IActionResult Get()
        {
            var items = _catalogRepository.GetCatalogItems();
            return new OkObjectResult(items);
        }
        // GET api/<CatalogController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _catalogRepository.GetCatalogItemByID(id);
            return new OkObjectResult(item);
        }
        // POST api/<CatalogController>
        [HttpPost]
        public IActionResult Post([FromBody] CatalogItem catalogItem)
        {
            using( var scope = new TransactionScope())
            {
                _catalogRepository.InsertCatalogItem(catalogItem);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = catalogItem.Id }, catalogItem);
            }
        }
        // PUT api/<CatalogController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] CatalogItem catalogItem)
        {
            if(catalogItem!=null)
            {
                using ( var scope = new TransactionScope())
                {
                    _catalogRepository.UpdateCatalogItem(catalogItem);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        // DELETE api/<CatalogController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _catalogRepository.DeleteCatalogItem(id);
            return new OkResult();
        }
    }
}
