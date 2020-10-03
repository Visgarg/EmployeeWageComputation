using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace EmployeeWageComputation
{
    class ComputeEmployeeWage
    {
        const int IS_PRESENT = 1;
        const int IS_PART_TIME = 2;
        //string companyName;
        //int wagePerHour;
        //int noOfWorkingDays;
        //int hoursPerMonth;
        NLog nLog = new NLog();
        public Dictionary<string, int> CompanyWageInDictionary;
        public EmployeeDetails[] companyWageArray;
        int companyIndex=0;
        /// <summary>
        /// Constructor of compute employee wage which instatiates array and dictionary.
        /// </summary>
        public ComputeEmployeeWage()
            {
            CompanyWageInDictionary = new Dictionary<string, int>();
            companyWageArray = new EmployeeDetails[5];
            }
        /// <summary>
        /// adding contact details by taking input from user, adding them to employeedetails object and assigning it to array of employeedetails object.
        /// </summary>
        /// <param name="companyName"></param>
        /// <param name="wagePerHour"></param>
        /// <param name="noOfWorkingDays"></param>
        /// <param name="hoursPerMonth"></param>
        public void AddContactDetails(string companyName, int wagePerHour, int noOfWorkingDays, int hoursPerMonth)
        {
            EmployeeDetails employeeDetails = new EmployeeDetails(companyName,wagePerHour,noOfWorkingDays,hoursPerMonth);
            companyWageArray[companyIndex] = employeeDetails;
            companyIndex++;
            
        }
        /// <summary>
        /// calculating monthly wages provides index to array and tranfer values to private monthly method which computes monthly wages and returns it.
        /// </summary>
        public void CalculateMonthlyWage()
        {
            ComputeEmployeeWage computeEmployeeWage = new ComputeEmployeeWage();
            for(int a=0;a<companyIndex;a++)
            {
                int monthlyWage=  computeEmployeeWage.CalculateMonthlyWage(companyWageArray[a]);
                companyWageArray[a].SetTotalWage(monthlyWage) ;
                CompanyWageInDictionary.Add(companyWageArray[a].companyName, monthlyWage);

            }
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="employeeDetail"></param>
       /// <returns></returns>
        internal  int CalculateMonthlyWage(EmployeeDetails employeeDetail)
        { 
            int fullDayHour;
            int workDayCount = 0;
            int totalWorkingHours = 0;
            int totalDailyWage;
            int monthlyWage;
            Console.WriteLine($"Employee wages for {employeeDetail.companyName}");
            //calculating total monthly wage by applying while loop on working days
            while (workDayCount < employeeDetail.noOfWorkingDays && totalWorkingHours <= employeeDetail.hoursPerMonth)
            {
                //using Random method to generate random no and compare with constants to check presence.
                Random random = new Random();
                int checkIfPresent = random.Next(0, 3);
                // instatiating compute employee wage class and calling WorkHours method which returns no of hours according to employee's presence.
                ComputeEmployeeWage computeEmployeeWage = new ComputeEmployeeWage();
                fullDayHour = computeEmployeeWage.WorkHours(checkIfPresent, workDayCount);
                if (totalWorkingHours + fullDayHour > employeeDetail.hoursPerMonth)
                {
                    fullDayHour = 0;
                }
                totalWorkingHours += fullDayHour;
                totalDailyWage = fullDayHour * employeeDetail.wagePerHour;
                Console.WriteLine($"Total daily wage is for {workDayCount + 1} is {totalDailyWage}");
                workDayCount++;
                //.LogDebug("Successfully Calculated daily employee wage : Main()");
            }
            monthlyWage = totalWorkingHours * employeeDetail.wagePerHour;
            nLog.LogDebug("Successfully calculated monthly employee wage: calculateMonthlyWage()");
            Console.WriteLine("********************************************************************");
            Console.WriteLine($"The monthly wage for employee of {employeeDetail.companyName} is {monthlyWage}");
              return monthlyWage;

        }
        /// <summary>
        /// Calculating Work hours after checking presence of employee.
        /// </summary>
        /// <param name="checkIfPresent"></param>
        /// <returns>int emphours</returns>
        public   int WorkHours(int checkIfPresent, int workDayCount)
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
        /// <summary>
        /// printing dictionary
        /// </summary>
        public void toString()
        {
            Console.WriteLine("**********************************************************************");
            foreach(var companywages in CompanyWageInDictionary)
            {
                nLog.LogInfo("Successfully printed all the values of companies and their employee wages: toString()");
                Console.WriteLine($"The employee wage of {companywages.Key} is {companywages.Value}");
            }
        }
    }
}

