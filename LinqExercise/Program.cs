using System;
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
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            Console.WriteLine("*******************************");
            //Print the Sum and Average of numbers
            var sum = numbers.Sum();
            var avg = numbers.Average();
            Console.WriteLine($"Sum : {sum}");
            Console.WriteLine($"Average : {avg}");


            //Order numbers in ascending order and decsending order. Print each to console.
            var asc = numbers.OrderBy(num => num);
            var desc = numbers.OrderByDescending(num => num);


            Console.WriteLine("*******************************");
            Console.WriteLine("Ascending order");
            foreach (var x in asc)
            {
                Console.WriteLine(x);
            }


            Console.WriteLine("*******************************");
            Console.WriteLine("Descending order");
            foreach (var x in desc)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("*******************************");
            //Print to the console only the numbers greater than 6
            var numbersGreaterThanSix = numbers.Where(num => num > 6);
            Console.WriteLine("Numbers greater than 6");
            foreach (var i in numbersGreaterThanSix)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("*******************************");
            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var printFour = desc.Take(4);
            Console.WriteLine("Descending order but only printing 4 items");
            foreach (var item in printFour)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("*******************************");
            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Changed the value at index 4 to your age, then print the numbers in decsending order");
            numbers[4] = 22;
            foreach (var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }


            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            Console.WriteLine("*******************************");
            Console.WriteLine("Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.");
            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            var filtered = 
                employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S'))
                .OrderBy(person => person.FirstName);
            Console.WriteLine("Ordered in ascending order by FirstName");
            //Order this in acesnding order by FirstName.
            foreach (var person in filtered)
            {
                Console.WriteLine($"{ person.FullName }");
            }


            Console.WriteLine("*******************************");
            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Print all the employees' FullName and Age who are over the age 26 to the console.");
            var personsOverTwentySix = employees.Where(person => person.Age > 26)
                .OrderBy(person => person.Age)
                .ThenBy(person => person.FirstName);

            foreach (var person in personsOverTwentySix)
            {
                Console.WriteLine($"Name: { person.FullName } - Age: { person.Age }");
            }



            Console.WriteLine("*******************************");
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var filteredAgeYOE = employees.Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35);
            var sumYOE = filteredAgeYOE.Sum(emp => emp.YearsOfExperience);
            var avgYOE = filteredAgeYOE.Average(emp => emp.YearsOfExperience);
            Console.WriteLine($"Sum: { sumYOE } and Average: { avgYOE }");



            Console.WriteLine("*******************************");
            //Add an employee to the end of the list without using employees.Add()
           var newList = employees.Append(new Employee("Olakunle" , "Neye" , 22, 6)).ToList();
            foreach (var emp in newList)
            {
                Console.WriteLine($"Employees: {emp.FullName} YOE: {emp.YearsOfExperience}");
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
