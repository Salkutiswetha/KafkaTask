using Producer.Models;
using Producer.ProducerWrapper;

namespace Producer.Employee;
public class EmployeeProducer
{
     List<EmployeeModel> employeeData = new List<EmployeeModel>()
       {
            new EmployeeModel()
            {
                Id = 1,
                Name = "Althaf",
                Age = 22,
                Designation = "software developer",
                Address = "warangal"
            },
            new EmployeeModel()
            {
                Id = 2,
                Name = "Althaf",
                Age = 22,
                Designation = "software developer",
                Address = "warangal"
            }
       };
    public async void start()
    {
       
        var producer = new ProducerWrapper.Producer();
        Console.WriteLine("came");
        producer.produce(employeeData);
    }
}