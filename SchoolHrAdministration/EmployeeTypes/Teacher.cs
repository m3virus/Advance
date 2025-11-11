using HRAdministrationApi;

namespace SchoolHrAdministration.EmployeeTypes;

internal class Teacher:EmployeeBase
{
    public override decimal Salary { get=> 1.02m * base.Salary; }
}