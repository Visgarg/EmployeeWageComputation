using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeWageComputation
{
    /// <summary>
    /// Interface for ComputeEmployeeWage class
    /// </summary>
    interface IComputeEmployeeWage
    {
        void AddContactDetails(string companyName, int wagePerHour, int noOfWorkingDays, int hoursPerMonth);
         void CalculateMonthlyWage();
         void toString();
    }
}
