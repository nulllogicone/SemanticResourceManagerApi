﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace SemanticResourceManagerService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private AppSettings appSettings;

        public ValuesController(IOptions<AppSettings> settings)
        {
            appSettings = settings.Value;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var resx = new ResourceEntity("ApplicationName", "en");
            resx.Label = $"first tests to store resources";

            var constr = appSettings.semanticresourcemanager_AzureStorageConnectionString;
            var storageClient = new StorageClient(constr);
            storageClient.UpsertResource(resx);

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {

            var resx = new ResourceEntity("ApplicationName", "en");
            resx.Label = $"first tests to store resources for [{id}]";
            resx.Description = $"Added {DateTime.Now}";

            var constr = appSettings.semanticresourcemanager_AzureStorageConnectionString;
            var storageClient = new StorageClient(constr);
            storageClient.UpsertResource(resx);


            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
