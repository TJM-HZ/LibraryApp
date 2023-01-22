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
            StringField("Title", true, bb.Title);
            StringField("Author", true, bb.Author);
            //StringField("Illustrator", false, bb.Illustrator);
            //StringField("Publisher", false, bb.Publisher);
            //StringField("Language", false, bb.Language);
            //StringField("Country", false, bb.Country);
            StringField("Print Length", true, bb.PrintLength);
            StringField("ISBN-10", false, bb.Isbn10);
            StringField("ISBN-13", false, bb.Isbn13);
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

        public void StringField(string fieldName, bool isRequired, Func<string, BookBuilder> method)
        {
            string input = InputField(fieldName, isRequired);

            if (isRequired && (input == null || input == ""))
            {
                // Clear the last line upon making an error
                ClearLine();

                StringField(fieldName, true, method);
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
                //TODO: Previous input isn't cleared but can be written over. The previous input seemingly does not exist but is shown on screen.
                //It doesn't affect the functioning of the app but it looks bad.
                ClearLine();

                StringField(fieldName, true, method);
            }
            else
            {
                try { method(short.Parse(input)); } 
                catch 
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', Console.BufferWidth));
                    Console.SetCursorPosition(0, Console.CursorTop - 1);

                    StringField(fieldName, true, method);
                }
            }
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
