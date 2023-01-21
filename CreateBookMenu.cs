using LibraryApp.Products.ProductBuilders;
using LibraryApp.Products.ProductTypes;
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
            StringField("Illustrator", false, bb.Illustrator);
            StringField("Publisher", false, bb.Publisher);
            StringField("Language", false, bb.Language);
            StringField("Country", false, bb.Country);
            StringField("Print Length", true, bb.PrintLength);
            StringField("ISBN-10", false, bb.Isbn10);
            StringField("ISBN-13", false, bb.Isbn13);
            Book newBook = bb.Build();
            Console.Clear();
            newBook.PrintDetails();
        }
        public void StringField(string fieldName, bool isRequired, Func<string, BookBuilder> method)
        {
            string input = InputField(fieldName, isRequired);

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

        //TODO: Lots of code repeated. Try refactoring (parts of) this
        //UPDATE: InputField is poorly named but removes some code duplication.
        public void StringField(string fieldName, bool isRequired, Func<int, BookBuilder> method)
        {
            string input = InputField(fieldName, isRequired);

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
                method(Int16.Parse(input));
            }
        }

        private static string InputField(string fieldName, bool isRequired)
        {
            string suffix = "";
            if (isRequired) { suffix = "*"; }

            Console.Write($"{fieldName}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{suffix}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(":");


            string input = Console.ReadLine();
            return input;
        }
    }
}
