using ProjectLibraryDAL;
using ProjectLibraryDAL.Models;
using System;

namespace ProjectLibraryConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProjectLibraryRepository repository = new ProjectLibraryRepository();
            //BookList bookList = new BookList();
            //bookList.BookName = "My Experiments With Truth";
            //bookList.Author = "Mahatma Gandhi";
            //bookList.YearOfPublication = 2022;
            //bookList.TotalQuantity = 5;

            bool result = repository.AddBook("My Experiments With Truth", "Mahatma Gandhi", 2022, 5);
            if (result)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failed");
            }
        }
    }
}
