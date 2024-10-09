using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using Azure.Messaging.EventGrid;
using System.Text.Json;
using System.Text.Json.Nodes;


namespace EventProcessorFunction
{
    public class JsonProcessor
    {
        [FunctionName("EventProcessor")]
        public void RunEventGridTrigger([EventGridTrigger] EventGridEvent eventGridEvent, ILogger log)
        {
            log.LogInformation($"C# Event grid trigger function Processed event :{eventGridEvent.Data.ToString()}");
            
            var jsonParsed = JsonNode.Parse(eventGridEvent.Data);

            var operationName = jsonParsed["operationName"].GetValue<string>();
            var resourceUri = jsonParsed["resourceUri"].GetValue<string>();
            log.LogInformation($"Got event for operation {operationName}...");
            if ("Microsoft.Compute/virtualMachines/deallocate/action".Equals(operationName))
            {
                log.LogInformation($"Virtual Machine deallocated: {resourceUri}. Do something here...");
            }
        }

    }
}
