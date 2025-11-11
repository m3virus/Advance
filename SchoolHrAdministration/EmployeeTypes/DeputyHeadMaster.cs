using HRAdministrationApi;

namespace SchoolHrAdministration.EmployeeTypes;

internal class DeputyHeadMaster:EmployeeBase
{
    public override decimal Salary { get => 1.03m * base.Salary; }
}