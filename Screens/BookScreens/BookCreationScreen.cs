using LibraryApp.Products.ProductBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens.BookScreens
{
    class BookCreationScreen : CreationScreen
    {
        public BookCreationScreen(App app, Screen previousScreen) : base(app, previousScreen) { }

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
            latestBook.PrintDetails(true);
            
            Console.WriteLine("New book added to the library");
            
            Console.WriteLine("Press any key to go back to the Book Hub");
            Console.ReadKey();
            App.ChangeScreen(PreviousScreen);
        }

        
    }
}
