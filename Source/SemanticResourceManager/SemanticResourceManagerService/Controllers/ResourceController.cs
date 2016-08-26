using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SemanticResourceManagerService.Controllers
{


    [Route("api/[controller]")]
    public class ResourceController : Controller
    {
        private readonly StorageClient _storageClient;

        public ResourceController(IOptions<AppSettings> settings)
        {
            var appSettings = settings.Value;
            var constr = appSettings.semanticresourcemanager_AzureStorageConnectionString;
            _storageClient = new StorageClient(constr);
        }

        // GET: api/values
        [HttpGet]
        public async Task<List<ResourceEntity>> Get()
        {
            var resx = await _storageClient.GetAllResourceEntityAsync();
            return resx;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string key, string language)
        {
           

            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ResourceEntity value)
        {
            var result = await _storageClient.UpsertResourceAsync(value);
            return Created(result.Etag, value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
