namespace hello
{
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual void PrintGreetings(string firstName, string lastName)
        {
            Console.WriteLine($"Hello {firstName} {lastName}.");
        }

    }
}