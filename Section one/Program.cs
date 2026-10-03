using System;
using System.Collections.Generic;

namespace Assignment08_Section01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>
            {
                new Book("111", "Clean Code", new[] { "Robert C. Martin" }, new DateTime(2008, 8, 1), 35.00M),
                new Book("222", "The Pragmatic Programmer", new[] { "Andy Hunt", "Dave Thomas" }, new DateTime(1999, 10, 30), 40.00M)
            };

            // Case (a): user-defined delegate
            LibraryEngine.ProcessBooks(books, new BookFunctionDelegate(BookFunctions.GetTitle));

            // Case (b): built-in delegate (Func<Book, string>)
            LibraryEngine.ProcessBooksFunc(books, BookFunctions.GetAuthors);

            // Case (c): anonymous method (GetISBN)
            LibraryEngine.ProcessBooksFunc(books, delegate (Book B)
            {
                return B.ISBN;
            });

            // Case (d): lambda expression (GetPublicationDate)
            LibraryEngine.ProcessBooksFunc(books, (B) => B.PublicationDate.ToString("d"));
        }
    }
}