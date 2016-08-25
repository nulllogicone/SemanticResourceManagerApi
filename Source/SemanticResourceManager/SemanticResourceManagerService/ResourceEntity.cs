using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace SemanticResourceManagerService
{
    public class ResourceEntity : TableEntity
    {
        public ResourceEntity(string partitionKey, string rowKey)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

        public string Label { get; set; }
    }
}
