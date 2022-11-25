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
    public static class GetAllMuseums
    {
        [FunctionName("GetAllMuseums")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "musei",
                collectionName: "museums",
                ConnectionStringSetting = "museiConnection",
                SqlQuery = "SELECT * from museums")]
                IEnumerable<Museum> museumItems,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            Dictionary<string, Museum> museums = new Dictionary<string, Museum>();
            foreach (Museum e in museumItems)
            {
                museums.Add(e.id, e);
            }
            return new OkObjectResult(museums);
        }
    }

    
}

