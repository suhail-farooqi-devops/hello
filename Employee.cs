namespace hello
{
    public class Employee : Person
    {
        public Department? Department { get; set; }

        public override void PrintGreetings(string firstName, string lastName)
        {
            var departmentName = Department?.Name ?? "No department assigned";
            Console.WriteLine($"Welcome valued employee {firstName} {lastName}! You work in the '{departmentName}' department.");
        }
    }
}
