using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using SemanticResourceManagerService.Storage;

namespace SemanticResourceManagerService.Model
{
    public class Resource
    {
        public Resource()
        {
            
        }

        public Resource(ResourceEntity resourceEntity)
        {
            PropertyCopy.Copy(resourceEntity,this);
            var keys = resourceEntity.PartitionKey.Split('-');
            ApplicationName = keys[0];
            Key = keys[1];
        }
        public string ApplicationName { get; set; }
        public string Key { get; set; }
        public string CultureName { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

        public ResourceEntity ToResourceEntity()
        {
            var partKey = $"{ApplicationName}-{Key}";
            var re = new ResourceEntity(partKey,CultureName);
            PropertyCopy.Copy(this,re);
            return re;
        }
    }
}
