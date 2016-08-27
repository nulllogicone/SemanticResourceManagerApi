﻿using Microsoft.WindowsAzure.Storage.Table;

namespace SemanticResourceManagerService.Storage
{
    public class ResourceEntity : TableEntity
    {
        public ResourceEntity()
        {
            
        }

        public ResourceEntity(string partitionKey, string rowKey)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

        public string CultureName
        {
            get { return RowKey; }
            set { RowKey = value; }
        }

        public string Label { get; set; }
        public string Description { get; set; }
    }
}