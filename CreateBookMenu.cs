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
            StringField("Title", true, bb, bb.Title);
            StringField("Author", true, bb, bb.Author);
        }
        public void StringField(string fieldName, bool isRequired, BookBuilder bb, Func<string, BookBuilder> method)
        {
            // TODO: Make line white once it's valid again
            string suffix = "";
            if (isRequired) { suffix = "*"; }

            Console.Write($"{fieldName}{suffix}: ");
            string input = Console.ReadLine();
            if (input == null || input == "")
            {
                // Clear the last line upon making an error
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new String(' ', Console.BufferWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);

                Console.ForegroundColor = ConsoleColor.Red;
                StringField(fieldName, true, bb, method);
                Console.ResetColor();
            }
            else
            {
                method(input);
            }
        }
    }
}
