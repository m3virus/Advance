using HRAdministrationApi;

namespace SchoolHrAdministration.EmployeeTypes;

internal class HeadOfDepartment : EmployeeBase
{
    public override decimal Salary { get => 1.06m * base.Salary; }
}