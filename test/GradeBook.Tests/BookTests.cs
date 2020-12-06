using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
        // Throwing Error
        /**
            /usr/local/share/dotnet/sdk/3.1.404/Microsoft.TestPlatform.targets(32,5): error MSB4181: The "Microsoft.TestPlatform.Build.Tasks.VSTestTask" task returned false but did not log an error. [/Users/rpaixao/Other/pluralsight/c#fundementals/gradebook/test/GradeBook.Tests/GradeBook.Tests.csproj]
        */

        // [Fact]
        // public void BookDisallowsInvalidGrades()
        // {
        //     // arrange
        //     var book = new Book("");
        //     book.AddGrade(105.0);
        //     book.AddGrade(90.0);

        //     // act
        //     var result = book.GetStatistics();

        //     // assert
        //     Assert.Equal(90.0, result.Average, 1);
        //     Assert.Equal(90.0, result.High, 1);
        //     Assert.Equal(90.0, result.Low, 1);
        // }
    }
}
