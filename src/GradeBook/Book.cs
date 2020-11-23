using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        // Constructor for Book class
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }
        public void ShowStatistics()
        {
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            foreach(var number in grades)
            {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Min(number, lowGrade);
                result += number;
            }
            result /= grades.Count;

            System.Console.WriteLine($"The highest grade is {highGrade:N1}");
            System.Console.WriteLine($"The average grade is {result:N1}");
            System.Console.WriteLine($"The lowest grade is {lowGrade:N1}");
        }
        // grades here is what's known as a "field".
        // A variable to keep track of state. Should be outside public method.
        private List<double> grades;
        private string name;
    }
}