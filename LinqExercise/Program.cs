using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Done: Print the Sum of numbers

            int sum = numbers.Sum();
            Console.WriteLine(sum);

            //Done: Print the Average of numbers

            int average = (int)numbers.Average();
            Console.WriteLine(average);

            //Done: Order numbers in ascending order and print to the console

            IEnumerable<int> ascendingOrder = numbers.OrderBy(results => results);
            foreach (var results in ascendingOrder)
            Console.WriteLine(results);

            
            //Done: Order numbers in decsending order and print to the console

            IEnumerable<int> decsendingOrder = numbers.OrderByDescending(descendingResults => descendingResults);
            foreach (var descendingResults in decsendingOrder)
            Console.WriteLine(descendingResults);

            //Done: Print to the console only the numbers greater than 6

            IEnumerable<int> numGreaterThan6 = numbers.Where(x => x > 6);
            foreach ( var x in numGreaterThan6)
            {
                Console.WriteLine(x);
            }


            //Done: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            IEnumerable<int> printOnly4 = numbers.OrderByDescending(print4Results => print4Results).Where(x => x < 4);
            foreach (var print4Results in printOnly4)
                Console.WriteLine(print4Results);


            //Done: Change the value at index 4 to your age, then print the numbers in decsending order

            numbers[4] = 33;
            IEnumerable<int> indexChange = numbers.OrderByDescending(myAge33 => myAge33);
            foreach (var myAge33 in indexChange)
                Console.WriteLine(myAge33);

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //Done: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.


            var filtered = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S'))
                .OrderBy(person => person.FirstName);

            Console.WriteLine("C or S Employees");
            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FullName);
            }


            //Done: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var overTwentySix = employees.Where(emp => emp.Age > 26)
                .OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName).ThenBy(emp => emp.YearsOfExperience);

            Console.WriteLine("Over 26");
            foreach (var person in overTwentySix)
            {
                Console.WriteLine($"Age; {person.Age} Fullname: {person.FirstName} YOE: {person.YearsOfExperience}");
            }



            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            var yoeEmployees = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            var sumOfYOE = yoeEmployees.Sum(emp => emp.YearsOfExperience);
            var avgOfYOE = yoeEmployees.Average(emp => emp.YearsOfExperience);

            Console.WriteLine($"Sum {sumOfYOE} Avg {avgOfYOE}");

            //TODO: Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("DeAdrien", "Hill", 33, 19)).ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.Age}");
            }
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
