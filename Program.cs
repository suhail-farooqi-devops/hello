using hello;

// var objPerson = new Person
// {
//     Id = 1,
//     FirstName = "Umar",
//     LastName = "Farooqi"
// };

// objPerson.PrintName(objPerson.FirstName, objPerson.LastName);

var objDepartment = new Department
{
    Id = 1,
    Name = "IT"
};

var objEmployee = new Employee
{
    Id = 1,
    FirstName = "Suhail",
    LastName = "Farooqi",
    Department = objDepartment
};

// objEmployee.PrintName(objEmployee.FirstName, objEmployee.LastName);
objEmployee.PrintEmployeeWithDepartment();
