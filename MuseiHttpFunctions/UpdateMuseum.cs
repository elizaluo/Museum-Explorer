using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MuseiHttpFunctions
{
    public static class UpdateMuseum
    {
        [FunctionName("UpdateMuseum")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "musei",
                collectionName: "museums",
                ConnectionStringSetting = "museiConnection")]
                IAsyncCollector<Museum> museums,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Museum updatedMuseum = JsonConvert.DeserializeObject<Museum>(requestBody);
            await museums.AddAsync(updatedMuseum);
            return new OkObjectResult(updatedMuseum);
        }
    }
}
