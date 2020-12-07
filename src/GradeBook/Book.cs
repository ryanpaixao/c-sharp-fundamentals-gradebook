using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject // Base Class
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }

  public class DiskBook : Book
  {
    public DiskBook(string name) : base(name)
    {
    }

    public override event GradeAddedDelegate GradeAdded;

    public override void AddGrade(double grade)
    {
        using(var writer = File.AppendText($"{Name}.txt"))
        {
            writer.WriteLine(grade);
            if(GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
        }
    }

    public override Statistics GetStatistics()
    {
        var result = new Statistics();

        using(var reader = File.OpenText($"{Name}.txt"))
        {
            var line = reader.ReadLine();
            while(line != null)
            {
                var number = double.Parse(line);
                result.Add(number);
                line = reader.ReadLine();
            }
        }

        return result;
    }
  }

  public class InMemoryBook : Book // Derived class Book from Base Class of NamedObject
    {
        // Constructor for Book class
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        public override void AddGrade(double grade) // Addgrade can be overridden because inherited method is abstract
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            for(var index = 0; index < grades.Count; index += 1)
            {
                result.Add(grades[index]);
            }

            return result;
        }
        // grades here is what's known as a "field".
        // A variable to keep track of state. Should be outside public method.
        private List<double> grades;

        // private string name;
        // public string Name
        // {
        //     get
        //     {
        //         return name;
        //     }
        //     set{
        //         if(!String.IsNullOrEmpty(value))
        //         {
        //             name = value;
        //         }
        //     }
        // }

        // bellow is succinct version of code above.

        public const string CATEGORY = "Science";
    }
}
