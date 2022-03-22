using Consumer.ConsumerWrapper;

namespace Consumer;

   public class Program
    {
       public static void Main(string[] args)
        {
            var studentConsumer  = new EmployeeConsumer();
            studentConsumer.Listen();
        }
    }
