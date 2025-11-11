using HRAdministrationApi;

namespace SchoolHrAdministration.EmployeeTypes;

internal class HeadMaster : EmployeeBase
{
    public override decimal Salary { get => 1.04m * base.Salary; }
}