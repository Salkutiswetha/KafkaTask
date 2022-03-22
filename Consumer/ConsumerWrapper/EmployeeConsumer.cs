using Confluent.Kafka;
using System.Text.Json;
using Consumer.Models;

namespace Consumer.ConsumerWrapper;

public class EmployeeConsumer : IEmployeeConsumer
{
    private readonly string topic = "topic";
    public void Listen()
    {

        var consumerConfiguration = new ConsumerConfig
        {
            GroupId = "student_consumer", //
            // BootstrapServers =  Environment.GetEnvironmentVariable("CONSUMER_PORT")//"localhost:9092"
            BootstrapServers = "localhost:9092"
        };
        try
        {
            using (var consumer = new ConsumerBuilder<string, string>(consumerConfiguration).Build())//
            {
                consumer.Subscribe(topic);
                while (true)
                {
                    var result = JsonSerializer.Deserialize<EmployeeModel>(consumer.Consume().Message.Value);
                    Console.WriteLine(result.Address);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured: {ex.Message}");
        }
    }

    public void listen(Action<string> message)
    {
        throw new NotImplementedException();
    }

    public void Listen(Action<string> message)
    {
        throw new NotImplementedException();
    }
}