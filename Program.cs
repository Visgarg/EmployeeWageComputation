using System;

namespace EmployeeWageComputation
{
    class Program
    {
        
        
        //const int IS_ABSENT = 0;
        NLog nLog = new NLog();
        /// <summary>
        /// Main method for calling welcome message and checking employee presence.
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            NLog nLog = new NLog();
            Console.WriteLine("Welcome to Employee Wage computation Program");
            nLog.LogInfo("Welcome message displayed : Main()");
            string checkForInput = "y";
            ComputeEmployeeWage computeEmployeeWage = new ComputeEmployeeWage();
            //instatiating computeEmployeewage class class for calling calculatemonthlywage method to calculate monthlywage.
            while (checkForInput.ToLower()=="y")
            {
                Console.WriteLine("Please enter the name of company");
                string nameOfCompany = Console.ReadLine();
                Console.WriteLine("Please enter wage per hour for company");
                int wagePerHour = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter no. of working days for company");
                int noOfWorkingDays = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter no. of working hours for month");
                int monthlyWorkingHours = Convert.ToInt32(Console.ReadLine());
                
                computeEmployeeWage.AddContactDetails(nameOfCompany, wagePerHour, noOfWorkingDays, monthlyWorkingHours);
                Console.WriteLine("Do you want to compute for another company, press y to compute.");
                checkForInput = Console.ReadLine();

            }
            computeEmployeeWage.CalculateMonthlyWage();
            computeEmployeeWage.toString();

        }
        
      
    }
}
