using System.Text.Json;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!!!");

        // Serialize
        var employee = new Employee
        {
            EmployeeId = "123",
            FirstName = "Tom",
            LastName = "Vaidyan",
            Email = "tom@test.com",
            Manager = new Employee
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "jsmith@test.com"
            }
        };

        var employeeJson = JsonSerializer.Serialize(employee, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented  = true   
        });

        Console.WriteLine(employeeJson);

        // Deserialize
        var jsonString = "{\"FirstName\":\"Tom\",\"LastName\":\"Vaidyan\",\"EmployeeId\":\"123\",\"Email\":\"tom@test.com\",\"Manager\":{\"FirstName\":\"John\",\"LastName\":\"Smith\",\"EmployeeId\":\"\",\"Email\":\"jsmith@test.com\",\"Manager\":null}}";
        var result = JsonSerializer.Deserialize<Employee>(jsonString);

    }
}

public class Employee
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmployeeId { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Employee? Manager { get; set; }
    [JsonPropertyName("deptId")]
    public int DepartmentId { get; set; }
}