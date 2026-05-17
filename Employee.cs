namespace hello
{
    public class Employee : Person
    {
        public Department? Department { get; set; }

        public void PrintEmployeeWithDepartment()
        {
            var deptName = Department?.Name ?? "(No Department)";
            Console.WriteLine($"Hello {FirstName} {LastName} you are in '{deptName}' department.");
        }
    }

}
