using System;
using System.Collections.Generic;

namespace Assignment08_Section01
{
    public class LibraryEngine
    {
        // ProcessBooks parameterized using the user-defined delegate
        // (case a). The same method signature (Func<Book, string> would
        // also fit case b) - see Program.cs for how each case is invoked.
        public static void ProcessBooks(List<Book> bList, BookFunctionDelegate fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

        // Overload using the built-in Func<> delegate (case b) - same
        // signature (Book in, string out), so Func<Book, string> is a
        // drop-in replacement for the user-defined delegate above.
        public static void ProcessBooks(List<Book> bList, Func<Book, string> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }
}
