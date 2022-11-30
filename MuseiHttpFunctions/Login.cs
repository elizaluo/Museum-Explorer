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
    public static class Login
    {
        [FunctionName("Login")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "login/{partitionKey}/{id}")] HttpRequest req,
            [CosmosDB(
                databaseName: "musei",
                collectionName: "users",
                ConnectionStringSetting = "museiConnection",
                Id = "{id}",
                PartitionKey = "{partitionKey}")]
                User user,
            ILogger log)
        {
            return new OkObjectResult(user);
        }
    }
}
