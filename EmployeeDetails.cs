using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeWageComputation
{
    class EmployeeDetails
    {
        public string companyName;
        public int wagePerHour;
        public int noOfWorkingDays;
        public int hoursPerMonth;
        public int totalMonthlyWage;

        public EmployeeDetails(string companyName, int wagePerHour, int noOfWorkingDays, int hoursPerMonth)
        {
            this.companyName = companyName;
            this.wagePerHour = wagePerHour;
            this.noOfWorkingDays = noOfWorkingDays;
            this.hoursPerMonth = hoursPerMonth;
            
        }
        public void SetTotalWage( int totalMonthlyWage)
        {
            this.totalMonthlyWage = totalMonthlyWage;
        }
    }
}
