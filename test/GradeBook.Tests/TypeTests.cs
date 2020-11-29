using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void StringsBehaveLikeValueTypes() // Even though they're technically Reference types
        {
            // Arrange
            string name = "Ryan";

            // Act
            var upper = MakeUppercase(name);

            // Assert
            Assert.Equal("RYAN", upper);
        }
        private string MakeUppercase(string param)
        {
            return param.ToUpper();
        }
        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            // Arange
            var x = GetInt();

            // Act
            SetInt(x);

            // Assert
            Assert.Equal(3, x);
        }
        private int GetInt()
        {
            return 3;
        }
        private void SetInt(int x)
        {
            x = 42;
        }
        [Fact]
        public void CSharpCanPassByRef()
        {
            // arrange
            var book1 = GetBook("Book 1");

            // act
            GetBookByRefSetName(ref book1, "New Name"); // ref and out are not used that often

            // assert
            Assert.Equal("New Name", book1.Name);
        }
        private void GetBookByRefSetName(ref Book book, string name) // ref and out are not used that often
        {
            book = new Book(name);
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            // arrange
            var book1 = GetBook("Book 1");

            // act
            GetBookSetName(book1, "New Name");

            // assert
            Assert.Equal("Book 1", book1.Name);
        }
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }
        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange
            var book1 = GetBook("Book 1");

            // act
            SetName(book1, "New Name");

            // assert
            Assert.Equal("New Name", book1.Name);
        }
        private void SetName(Book book, string name)
        {
            book.Name = name;
        }
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // act

            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }
        [Fact]
        public void TwoVarsCanReferenceSameObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            // act

            // assert
            Assert.Same(book1, book2);
        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
