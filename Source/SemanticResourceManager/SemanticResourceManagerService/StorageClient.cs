using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Framework.Configuration;
using Microsoft.WindowsAzure.Storage.Table;

namespace SemanticResourceManagerService
{
    public class StorageClient
    {
        private CloudTable resourceTable;

        public StorageClient(string storageConnectionString)
        {
            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            resourceTable = tableClient.GetTableReference("resources");
            resourceTable.CreateIfNotExists();
        }
        public void UpsertResource(ResourceEntity resourceEntity)
        {
            TableOperation insertOperation = TableOperation.Insert(resourceEntity);

            // Execute the insert operation.
            resourceTable.Execute(insertOperation);
        }
    }
}
