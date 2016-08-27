using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SemanticResourceManagerService.Model;
using SemanticResourceManagerService.Storage;

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
        public async Task<List<Resource>> Get()
        {
            var resEnts = await _storageClient.GetAllResourceEntityAsync();
            var resx = resEnts.Select(resourceEntity => new Resource(resourceEntity)).ToList();
            return resx;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string applicationName, string key, string language)
        {
           

            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Resource resource)
        {            
            var result = await _storageClient.UpsertResourceAsync(resource.ToResourceEntity());
            return Created(result.Etag, resource);
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
