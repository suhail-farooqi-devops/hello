using hello;
using Microsoft.EntityFrameworkCore;

using var db = new AppDbContext();
db.Database.EnsureCreated();

Console.WriteLine("SQLite CRUD App");

while (true)
{
    Console.WriteLine();
    Console.WriteLine("1) Add department");
    Console.WriteLine("2) List departments");
    Console.WriteLine("3) Add employee");
    Console.WriteLine("4) List employees");
    Console.WriteLine("5) Update employee");
    Console.WriteLine("6) Delete employee");
    Console.WriteLine("0) Exit");
    Console.Write("Choose an option: ");
    var choice = Console.ReadLine()?.Trim();

    switch (choice)
    {
        case "1": AddDepartment(db); break;
        case "2": ListDepartments(db); break;
        case "3": AddEmployee(db); break;
        case "4": ListEmployees(db); break;
        case "5": UpdateEmployee(db); break;
        case "6": DeleteEmployee(db); break;
        case "0": return;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

static void AddDepartment(AppDbContext db)
{
    Console.Write("Department name: ");
    var name = Console.ReadLine()?.Trim();
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Department name cannot be empty.");
        return;
    }

    db.Departments.Add(new Department { Name = name });
    db.SaveChanges();
    Console.WriteLine("Department saved.");
}

static void ListDepartments(AppDbContext db)
{
    var departments = db.Departments.OrderBy(d => d.Id).ToList();
    if (!departments.Any())
    {
        Console.WriteLine("No departments found.");
        return;
    }

    foreach (var department in departments)
    {
        Console.WriteLine($"{department.Id}: {department.Name}");
    }
}

static void AddEmployee(AppDbContext db)
{
    Console.Write("First name: ");
    var firstName = Console.ReadLine()?.Trim();
    Console.Write("Last name: ");
    var lastName = Console.ReadLine()?.Trim();
    if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
    {
        Console.WriteLine("First name and last name are required.");
        return;
    }

    var departments = db.Departments.OrderBy(d => d.Id).ToList();
    if (!departments.Any())
    {
        Console.WriteLine("Add a department first.");
        return;
    }

    foreach (var department in departments)
    {
        Console.WriteLine($"{department.Id}) {department.Name}");
    }
    Console.Write("Department id: ");
    var idValue = Console.ReadLine()?.Trim();
    if (!int.TryParse(idValue, out var departmentId) || !departments.Any(d => d.Id == departmentId))
    {
        Console.WriteLine("Invalid department.");
        return;
    }

    db.Employees.Add(new Employee
    {
        FirstName = firstName,
        LastName = lastName,
        Department = db.Departments.Find(departmentId)
    });
    db.SaveChanges();
    Console.WriteLine("Employee saved.");
}

static void ListEmployees(AppDbContext db)
{
    var employees = db.Employees.Include(e => e.Department).OrderBy(e => e.Id).ToList();
    if (!employees.Any())
    {
        Console.WriteLine("No employees found.");
        return;
    }

    foreach (var employee in employees)
    {
        var departmentName = employee.Department?.Name ?? "(No department)";
        Console.WriteLine($"{employee.Id}: {employee.FirstName} {employee.LastName} - {departmentName}");
    }
}

static void UpdateEmployee(AppDbContext db)
{
    Console.Write("Employee id: ");
    var idValue = Console.ReadLine()?.Trim();
    if (!int.TryParse(idValue, out var employeeId))
    {
        Console.WriteLine("Invalid id.");
        return;
    }

    var employee = db.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == employeeId);
    if (employee is null)
    {
        Console.WriteLine("Employee not found.");
        return;
    }

    Console.Write($"New first name ({employee.FirstName}): ");
    var firstName = Console.ReadLine()?.Trim();
    Console.Write($"New last name ({employee.LastName}): ");
    var lastName = Console.ReadLine()?.Trim();

    if (!string.IsNullOrWhiteSpace(firstName)) employee.FirstName = firstName;
    if (!string.IsNullOrWhiteSpace(lastName)) employee.LastName = lastName;

    var departments = db.Departments.OrderBy(d => d.Id).ToList();
    foreach (var department in departments)
    {
        Console.WriteLine($"{department.Id}) {department.Name}");
    }
    Console.Write($"New department id ({employee.Department?.Id ?? 0}): ");
    var deptValue = Console.ReadLine()?.Trim();
    if (int.TryParse(deptValue, out var departmentId) && departments.Any(d => d.Id == departmentId))
    {
        employee.Department = db.Departments.Find(departmentId);
    }

    db.SaveChanges();
    Console.WriteLine("Employee updated.");
}

static void DeleteEmployee(AppDbContext db)
{
    Console.Write("Employee id: ");
    var idValue = Console.ReadLine()?.Trim();
    if (!int.TryParse(idValue, out var employeeId))
    {
        Console.WriteLine("Invalid id.");
        return;
    }

    var employee = db.Employees.Find(employeeId);
    if (employee is null)
    {
        Console.WriteLine("Employee not found.");
        return;
    }

    db.Employees.Remove(employee);
    db.SaveChanges();
    Console.WriteLine("Employee deleted.");
}
