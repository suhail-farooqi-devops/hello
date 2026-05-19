using hello;

var objDepartment = new Department
{
    Id = 1,
    Name = "Information Technology"
};

var objEmployee = new Employee
{
    Id = 1,
    FirstName = "Mohammad Umar",
    LastName = "Farooqi",
    Department = objDepartment
};

objEmployee.PrintGreetings(objEmployee.FirstName, objEmployee.LastName);
