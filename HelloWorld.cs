using System;
using System.IO;
using Azure.Storage.Blobs;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Storage.Blobs.Models;
// test
namespace function_res
{
    public static class HelloWorld
    {
        [FunctionName("HelloWorld")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            const string BLOB_CONTAINER = "$web";


            string connString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            string BlobUri = "menu.json";
            var blob = new BlobClient(connString, BLOB_CONTAINER, BlobUri);                                                        // check file download was success or no
            var content = await blob.OpenReadAsync(); // I don't know what you want to do with this
            StreamReader reader = new StreamReader(content);
            string RawMenu = reader.ReadToEnd();






            return new OkObjectResult(RawMenu);
        }
    }
}
