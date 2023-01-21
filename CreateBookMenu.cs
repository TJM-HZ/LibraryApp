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
            Console.Write($"Fields marked with ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"*");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" are required\n");
            StringField("Title", true, bb.Title);
            StringField("Author", false, bb.Author);
        }
        public void StringField(string fieldName, bool isRequired, Func<string, BookBuilder> method)
        {
            // TODO: Make line white once it's valid again

            string suffix = "";
            if (isRequired) { suffix = "*"; }

            Console.Write($"{fieldName}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{suffix}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(":");


            string input = Console.ReadLine();
            
            if (isRequired && (input == null || input == ""))
            {
                // Clear the last line upon making an error
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new String(' ', Console.BufferWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);

                //Console.ForegroundColor = ConsoleColor.Red;
                StringField(fieldName, true, method);
                //Console.ResetColor();
            }
            else
            {
                method(input);
            }
        }
    }
}
