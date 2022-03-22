using Confluent.Kafka;
using Producer.Models;
using System.Text.Json;

namespace Producer.ProducerWrapper;

public class Producer
{
    public void produce(List<EmployeeModel> employeeData)
    {
        //var Servers = Environment.GetEnvironmentVariable(BOOTSTRAP_SERVER);
        var producerConfig = new ProducerConfig
        {
           // BootstrapServers = Environment.GetEnvironmentVariable("BOOTSTRAP_SERVER")
           BootstrapServers= "localhost:9092"
        };
        using (var producer = new ProducerBuilder<string, string>(producerConfig).Build())
        {


            string topic = "topic";

            int i = 1;
            try
            {
                foreach (var employee in employeeData)
                {
                    Console.WriteLine(employee);

                    var Value1 = JsonSerializer.Serialize(employee);
                    var key1 = "althaf" + 1;

                    producer.Produce(topic, new Message<string, string>
                    {
                        Key = key1,
                        Value = Value1
                    });
                    i++;
                    producer.Flush(TimeSpan.FromSeconds(1));
                    //Console.WriteLine($"Delivered '{delivaryResult.Value}' to '{delivaryResult.TopicPartitionOffset}'");


                    Console.WriteLine("result");
                }

            }
            catch (ProduceException<string, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"error occured in producer : {e}");
            }
        }
    }
}