using HRAdministrationApi;

namespace SchoolHrAdministration.EmployeeTypes
{
    public static class DataSeeder
    {
        public static void DataSeedEmployee(out List<IEmployee> employees)
        {
            employees = new List<IEmployee>();
            var teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher,
                FirstName : "Ahmad",
                LastName : "Ahmadi",
                id : 222,
                Salary : 40000
                );
            var teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher,
                FirstName: "Zahra",
                LastName: "Ahmadi",
                id: 223,
                Salary: 50000
            );
            
            employees.Add(teacher1);
            employees.Add(teacher2);

            var headMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher,
                FirstName: "Shayan",
                LastName: "Ahmadi",
                id: 224,
                Salary: 60000
            );
            employees.Add(headMaster);


            var deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher,
                FirstName: "Fatemeh",
                LastName: "Ahmadi",
                id: 225,
                Salary: 60000
            );
            
            employees.Add(deputyHeadMaster);

            var headOfDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher,
                FirstName: "Zohre",
                LastName: "Ahmadi",
                id: 226,
                Salary: 60000
            );

            employees.Add(headOfDepartment);
        }
    }
}
