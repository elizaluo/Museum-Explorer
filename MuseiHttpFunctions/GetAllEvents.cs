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
    public static class GetAllEvents
    {
        [FunctionName("GetAllEvents")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "musei",
                collectionName: "events",
                ConnectionStringSetting = "museiConnection",
                SqlQuery = "SELECT * from events")]
                IEnumerable<Event> eventItems,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            Dictionary<string, Event> events = new Dictionary<string, Event>();
            foreach (Event e in eventItems)
            {
                events.Add(e.id, e);
            }
            return new OkObjectResult(events);
        }
    }

    
}