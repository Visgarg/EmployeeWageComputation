using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace EmployeeWageComputation
{
    class ComputeEmployeeWage
    {
        const int IS_PRESENT = 1;
        const int IS_PART_TIME = 2;
        NLog nLog = new NLog();
        /// <summary>
        /// calculating monthly wages of employee
        /// </summary>
        public void CalculateMonthlyWage()
        {
            int wagePerHour = 20;
            int fullDayHour;
            int workDayCount = 0;
            int noOfWorkingDays = 20;
            int hoursPerMonth = 100;
            int totalWorkingHours = 0;
            int totalDailyWage;
            int monthlyWage;
            //calculating total monthly wage by applying while loop on working days
            while (workDayCount < noOfWorkingDays && totalWorkingHours <= hoursPerMonth)
            {
                //using Random method to generate random no and compare with constants to check presence.
                Random random = new Random();
                int checkIfPresent = random.Next(0, 3);
                // instatiating compute employee wage class and calling WorkHours method which returns no of hours according to employee's presence.
                ComputeEmployeeWage computeEmployeeWage = new ComputeEmployeeWage();
                fullDayHour = computeEmployeeWage.WorkHours(checkIfPresent, workDayCount);
                if (totalWorkingHours + fullDayHour > hoursPerMonth)
                {
                    fullDayHour = 0;
                }
                totalWorkingHours += fullDayHour;
                totalDailyWage = fullDayHour * wagePerHour;
                Console.WriteLine($"Total daily wage is for {workDayCount + 1} is {totalDailyWage}");
                workDayCount++;
                //.LogDebug("Successfully Calculated daily employee wage : Main()");
            }
            monthlyWage = totalWorkingHours * wagePerHour;
            nLog.LogDebug("Successfully calculated monthly employee wage: calculateMonthlyWage()");
            Console.WriteLine("********************************************************************");
            Console.WriteLine("The monthly wage of an employee is " + monthlyWage);
        }
        /// <summary>
        /// Calculating Work hours after checking presence of employee.
        /// </summary>
        /// <param name="checkIfPresent"></param>
        /// <returns>int emphours</returns>
        public int WorkHours(int checkIfPresent, int workDayCount)
        {
            switch (checkIfPresent)
            {
                case IS_PRESENT:
                    Console.WriteLine($"Employee is present on {workDayCount + 1} day.");
                    nLog.LogDebug("Debug successful, for employee presence: WorkHours()");
                    return 8;
                case IS_PART_TIME:
                    Console.WriteLine($"Employee is present for part time on {workDayCount + 1} day.");
                    nLog.LogDebug("Debug successful, for employee presence: WorkHours()");
                    return 4;
                default:
                    Console.WriteLine($"Employee is Absent on {workDayCount + 1}");
                    nLog.LogDebug("Debug successful, for employee presence: WorkHours()");
                    return 0;
            }
        }
    }
}
