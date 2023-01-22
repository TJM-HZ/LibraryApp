using LibraryApp.Products.ProductBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens.BookScreens
{
    class BookCreationScreen : Screen
    {
        public BookCreationScreen(App app) : base(app) { }

        public override void Run()
        {
            BookBuilder bb = BookBuilder.GetInstance();
            GlobalLibrary glib = GlobalLibrary.GetInstance();

            Console.Clear();
            Console.WriteLine("Creating a new book");
            Console.Write($"Fields marked with ");
            requiredSuffix();

            Console.Write(" are required\n");
            bb.Title(StringField("Title", true));
            bb.Author(StringField("Author", true));

            bb.PrintLength(IntField("Print Length", true));
            
            bb.Isbn10(StringField("ISBN-10", false));
            bb.Isbn13(StringField("ISBN-13", false));
            glib.addBook(bb.Build());
            
            Console.Clear();
            var latestBook = glib.Books.Last();
            latestBook.PrintDetails();
            
            Console.WriteLine("New book added to the library");
            
            Console.WriteLine("Press any key to go back to the Book Hub");
            Console.ReadKey();
            App.ChangeScreen(new BookHubScreen(App));
        }

        private static void requiredSuffix()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"*");
            Console.ForegroundColor = color;
        }

        public string StringField(string fieldName, bool isRequired)
        {
            string input = InputField(fieldName, isRequired);

            if (isRequired && (input == null || input == ""))
            {
                // Clear the last line upon making an error
                ClearLine();

                StringField(fieldName, isRequired);
            }
            return input;
        }

        //TODO: Lots of code repeated. Try refactoring (parts of) this
        //UPDATE: InputField is poorly named but removes some code duplication.

        public int IntField(string fieldName, bool isRequired)
        {
            string input = InputField(fieldName, isRequired);
            int number = 0; // Default value to stop the compiler from complaining

            if (isRequired && (input == null || input == ""))
            {
                //TODO: Previous input isn't cleared but can be written over. The previous input seemingly does not exist but is shown on screen.
                //It doesn't affect the functioning of the app but it looks bad.
                ClearLine();

                IntField(fieldName, isRequired);
            }
            else
            {
                try { 
                    number = short.Parse(input); 
                } catch
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', Console.BufferWidth));
                    Console.SetCursorPosition(0, Console.CursorTop - 1);

                    IntField(fieldName, isRequired);
                }
            }
            return number;
        }

        //TODO: Add this to a utility class of some kind.
        private static void ClearLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        private static string InputField(string fieldName, bool isRequired)
        {
            Console.Write($"{fieldName}");
            if(isRequired) requiredSuffix();
            Console.Write(":");

            string input = Console.ReadLine();
            return input;
        }
    }
}
