using System;
using IQ.Foundation.Messaging;
using IQ.Foundation.Messaging.AzureServiceBus;
using PushMessages.MessageFactories;
using PushMessages.MessageFactories.RqPricingForUpsert;

namespace PushMessages
{
    class Program
    {
        private const int CompanyId = 21090;
        private const int PriceSheetId = 35;
        private static readonly DateTime? StartDateUtc = new DateTime(2018,02,01);
        private static readonly DateTime? StopDateUtc = new DateTime(2018,02,28,23,59,59);
        private const string PricingUpsertQueue = "iq.Pricingupsert.AaronK";

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(@"**************************************");
                Console.WriteLine(@"*** M E S S A G E  P  R O D U C E R ***");
                Console.WriteLine(@"**************************************");

                var bootstrapper =
                    new DefaultAzureServiceBusBootstrapper(new IqPricingUpsertQueueProducerConfiguration());
                var messagePublisher = bootstrapper.BuildQueueProducer();

                SendMessages(messagePublisher);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine(@"Press Enter to quit . . .");
                Console.ReadLine();
            }
        }


        private static void SendMessages(IEnqueueMessages messagePublisher)
        {
            Console.WriteLine();
            Console.WriteLine(@"**********");
            Console.WriteLine();

            var priceSheetChangeMessageFactory = new UpsertPriceSheetChangeMessageFactoryMessageFactory(CompanyId, PriceSheetId, StartDateUtc, StopDateUtc);
            var rqPricingForUpsertMessageFactory = new RqPricingForUpsertMessageFactory(CompanyId, PriceSheetId, StartDateUtc, StopDateUtc);

            Console.WriteLine(@"Publish messages for PriceSheetChange or RqPricingForUpsert");
            Console.WriteLine(@"Enter (1) for PriceSheetChange messages");
            Console.WriteLine(@"Enter (2) for RqPricingForUpsert messages");
            Console.WriteLine(@"Enter (3) for RqPricingForUpsertSecondGeneration messages");
            Console.WriteLine();

            var messageType = Console.ReadLine();
            int messageTypeRequested;
            if(int.TryParse(messageType, out messageTypeRequested))
                switch (messageTypeRequested)
                {
                    case 1:
                        var priceSheetChangeMessage = priceSheetChangeMessageFactory.BuildMessage();

                        WriteOutputHeader(priceSheetChangeMessage);
                        messagePublisher.Enqueue(PricingUpsertQueue, priceSheetChangeMessage);

                        break;
                        
                    case 2:

                        var rqPricingForUpsertMessages = rqPricingForUpsertMessageFactory.BuildMessages(10);
                        foreach (var rqPricingForUpsert in rqPricingForUpsertMessages)
                        {
                            WriteOutputHeader(rqPricingForUpsert);
                            messagePublisher.Enqueue(PricingUpsertQueue, rqPricingForUpsert);
                        }

                        break;

                    case 3:
                        var rqPricingForUpsertSecondGenerationMessages = rqPricingForUpsertMessageFactory.BuildSecondGenerationMessages();
                        foreach (var rqPricingForUpsert in rqPricingForUpsertSecondGenerationMessages)
                        {
                            WriteOutputHeader(rqPricingForUpsert);
                            messagePublisher.Enqueue(PricingUpsertQueue, rqPricingForUpsert);
                        }

                        break;

                    default:
                        Console.WriteLine(@"Invalid message type requested.");
                        break;
                }

        }

        private static void WriteOutputHeader<T>(T message)
        {
            Console.WriteLine();
            Console.WriteLine(@"Producing message '{0}' . . .", message);
            Console.WriteLine();
        }
    }
}
