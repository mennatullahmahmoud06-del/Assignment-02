using System;
using System.Collections.Generic;

namespace Assignment08_Section01
{
    public class LibraryEngine
    {
        // ProcessBooks parameterized using the user-defined delegate (case a).
        // The same method signature (Func<Book, string> would  also fit case b) 
        public static void ProcessBooks(List<Book> bList, BookFunctionDelegate fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

        // Case (b): same behavior, but accepting the built-in Func<> instead
        // of the user-defined delegate. 
        public static void ProcessBooksFunc(List<Book> bList, Func<Book, string> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }
}