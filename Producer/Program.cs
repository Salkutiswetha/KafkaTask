using Producer.Employee;

public class Program
{
    public static void Main(string[] args)
    {
       var employeeProducer = new EmployeeProducer();
       employeeProducer.start();
        
    }
}