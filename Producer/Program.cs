using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;


namespace Producer
{
    class Program
    {
        public static async Task Main()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

           
            using var p = new ProducerBuilder<Null, string>(config).Build();

            var i = 0;
            while (true)
            {
               
                var message = new Message<Null, string>
                {
                    Value = $"Message #{++i}"
                };

                              
                var dr = await p.ProduceAsync("test", message);
                Console.WriteLine(
                    $"Produced message '{dr.Value}' to topic {dr.Topic}, partition {dr.Partition}, offset {dr.Offset}");

                Thread.Sleep(5000);
            }
        }
    }
}