using SchoolHrAdministration.EmployeeTypes;

decimal TotalSalaries = 0;

DataSeeder.DataSeedEmployee(out var emp);

foreach (var counter in emp)
{
    Console.WriteLine($"{counter.FirstName} {counter.LastName} salary is : {counter.Salary}");
    //TotalSalaries += counter.Salary;
}

Console.WriteLine(emp.Sum(x => x.Salary));

Console.ReadKey();