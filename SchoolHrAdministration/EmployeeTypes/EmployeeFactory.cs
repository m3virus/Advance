using HRAdministrationApi;

namespace SchoolHrAdministration.EmployeeTypes
{
    internal class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType Type,
            int id,
            string FirstName,
            string LastName,
            decimal Salary
            )
        {
            IEmployee instance = Type switch
            {
                EmployeeType.Teacher => FactoryPattern<IEmployee, Teacher>.GetInstance(),
                EmployeeType.DeputyHeadMaster => FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance(),
                EmployeeType.HeadMaster => FactoryPattern<IEmployee, HeadMaster>.GetInstance(),
                EmployeeType.HeadOfDepartment => FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance(),
                _ => throw new NotImplementedException()
            };
            if (instance != null)
            {
                instance.Salary = Salary;
                instance.FirstName = FirstName;
                instance.LastName = LastName;
                instance.Id = id;
            }
            else
            {
                throw new NotImplementedException();
            }
            return instance;
        }
    }
}
