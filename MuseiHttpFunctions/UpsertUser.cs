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
    public static class UpsertUser
    {
        [FunctionName("UpsertUser")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "musei",
                collectionName: "users",
                ConnectionStringSetting = "museiConnection")]
                IAsyncCollector<User> users,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            User newUser = JsonConvert.DeserializeObject<User>(requestBody);
            await users.AddAsync(newUser);
            return new OkObjectResult(newUser);
        }
    }    
}
