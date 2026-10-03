using System;

namespace Assignment08_Section01
{
    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return B.Title;
        }

        public static string GetAuthors(Book B)
        {
            return string.Join(", ", B.Authors);
        }

        public static string GetPrice(Book B)
        {
            return B.Price.ToString("C");
        }

        // Added to support the Anonymous Method 
        public static string GetISBN(Book B)
        {
            return B.ISBN;
        }

        public static string GetPublicationDate(Book B)
        {
            return B.PublicationDate.ToString("d");
        }
    }
}
