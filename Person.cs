namespace hello
{
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public void PrintName(string firstName, string lastName)
        {
            Console.WriteLine($"Hello {firstName} {lastName}.");
        }

    }
}