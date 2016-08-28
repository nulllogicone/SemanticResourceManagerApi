using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace SemanticResourceManagerService.Storage
{
    public class StorageClient
    {
        private readonly CloudTable _resourceTable;

        public StorageClient(string storageConnectionString)
        {
            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            _resourceTable = tableClient.GetTableReference("resources");
            _resourceTable.CreateIfNotExists();
        }

        public async Task<List<ResourceEntity>> GetAllResourceEntityAsync()
        {
            var resx = new List<ResourceEntity>();
            var getAllQuery = new TableQuery<ResourceEntity>();
            TableContinuationToken token = null;
            do
            {
                var queryResult = await _resourceTable.ExecuteQuerySegmentedAsync(getAllQuery, token);
                resx.AddRange(queryResult);
                token = queryResult.ContinuationToken;
            } while (token != null);
            return resx;


        }
        public async Task<TableResult> UpsertResourceAsync(ResourceEntity resourceEntity)
        {
            var insertOperation = TableOperation.InsertOrMerge(resourceEntity);

            // Execute the insert operation.
            var result = await _resourceTable.ExecuteAsync(insertOperation);
            return result;
        }
    }
}
