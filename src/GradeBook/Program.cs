using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 34.1;
            double y = 35.9;
            var result = x + y;
            Console.WriteLine(result);

            var numbers = new double[3];
            numbers[0] = 100;
            numbers[1] = 30;
            numbers[2] = 20;
            Console.WriteLine(numbers[0] + numbers[1] + numbers[2]);

            var numbers2 = new[] { 10, 2, 4, 6, 8 };
            var result2 = numbers2[0];
            result2 += numbers2[1];
            result2 += numbers2[2];
            result2 += numbers2[3];
            result2 += numbers2[4];
            Console.WriteLine(result2);

            var numbers3 = new[] { 1, 2, 3, 4, 5, 6 };
            var result3 = 1;
            foreach(int number in numbers3)
            {
                result3 *= number;
            }
            System.Console.WriteLine(result3);

            var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 };
            grades.Add(56.1);
            var result4 = 0.0;
            foreach(var grade in grades)
            {
                result4 += grade;
            }
            result4 /= grades.Count;
            System.Console.WriteLine(grades.Count);
            System.Console.WriteLine($"The average grade is {result4}");

            if(args.Length > 0)
            {
                Console.WriteLine($"Hello {args[0]}!");
            }
            else
            {
                Console.WriteLine("Hello you!!");
            }
        }
    }
}
