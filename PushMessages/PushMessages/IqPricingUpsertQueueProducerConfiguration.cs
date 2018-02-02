using IQ.Foundation.Messaging.AzureServiceBus.Configuration;

namespace PushMessages
{
    public class IqPricingUpsertQueueProducerConfiguration : ConventionServiceBusConfiguration
    {
        public override string ConnectionString => "[PUT CONNECTION STRING HERE]";
        public override string ServiceIdentifier => "iq.pricingupsert.AaronK";
    }
}