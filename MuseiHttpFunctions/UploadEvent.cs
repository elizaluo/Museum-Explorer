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
    public static class UploadEvent
    {
        [FunctionName("UploadEvent")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "musei",
                collectionName: "events",
                ConnectionStringSetting = "museiConnection")]
                IAsyncCollector<Event> events,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Event newEvent = JsonConvert.DeserializeObject<Event>(requestBody);
            await events.AddAsync(newEvent);
            return new OkObjectResult(newEvent);
        }
    }
}