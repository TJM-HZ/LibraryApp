using LibraryApp.Products.ProductBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    internal class CreateBookMenu
    {
        public CreateBookMenu(BookBuilder bb)
        {
            Console.Clear();
            Console.WriteLine("Creating a new book");
            Console.WriteLine("Fields marked with * are required");
            RequiredStringField("Title", bb, bb.Title);
            RequiredStringField("Author", bb, bb.Author);
        }
        public void RequiredStringField(string fieldName, BookBuilder bb, Func<string, BookBuilder> method)
        {
            Console.Write($"{fieldName}*: ");
            string input = Console.ReadLine();
            if (input == null || input == "")
            {
                Console.Clear();
                RequiredStringField(fieldName, bb, method);
            }
            else
            {
                method(input);
            }
        }
    }
}
