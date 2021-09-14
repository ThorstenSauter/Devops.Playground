using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Devops.Playground.Api;

public class HelloFunctions
{
    private readonly ILogger<HelloFunctions> _logger;

    public HelloFunctions(ILogger<HelloFunctions> logger) =>
        _logger = logger;

    [Function("HelloFunctions")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
        FunctionContext executionContext)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request");
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
        response.WriteString("Welcome to Azure Functions!");
        return response;
    }
}