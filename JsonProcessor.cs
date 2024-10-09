using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using Azure.Messaging.EventGrid;

namespace EventProcessorFunction
{
    public class JsonProcessor
    {
        [FunctionName("EventProcessor")]
        public void RunEventGridTrigger([EventGridTrigger] EventGridEvent eventGridEvent, ILogger log)
        {
            log.LogInformation($"C# Event grid trigger function Processed event :{eventGridEvent.Data.ToString()}");
        }

    }
}
