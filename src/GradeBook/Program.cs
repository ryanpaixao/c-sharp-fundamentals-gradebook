using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
    {
      var book = new Book("Ryan's Grade Book");
      book.GradeAdded += OnGradeAdded;

      // Add user input from terminal
      EnterGrades(book);

      var stats = book.GetStatistics();

      System.Console.WriteLine($"For the category named {Book.CATEGORY}");
      System.Console.WriteLine($"For the book named {book.Name}");
      System.Console.WriteLine($"The lowest grade is {stats.Low:N1}");
      System.Console.WriteLine($"The highest grade is {stats.High:N1}");
      System.Console.WriteLine($"The average grade is {stats.Average:N1}");
      System.Console.WriteLine($"The letter grade is {stats.Letter}");
    }

    private static void EnterGrades(Book book)
    {
      while (true)
      {
        System.Console.WriteLine("Enter a grade or 'q' to quit");
        var input = Console.ReadLine();

        if (input == "q")
        {
          break;
        }

        try
        {
          var grade = double.Parse(input);
          book.AddGrade(grade);
        }
        catch (ArgumentException ex)
        {
          System.Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
          System.Console.WriteLine(ex.Message);
        }
        finally
        {
          System.Console.WriteLine("**");
        }
      }
    }

    static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("Grade has been added!!");
        }
    }
}
