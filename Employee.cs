namespace hello
{
    public class Employee : Person
    {
        public Department? Department { get; set; }

        public override void PrintGreetings(string firstName, string lastName)
        {
            var deptName = Department?.Name ?? "No department assigned";
            Console.WriteLine($"Welcome valued employee {firstName} {lastName}! You work in the '{deptName}' department.");
        }
    }
}
