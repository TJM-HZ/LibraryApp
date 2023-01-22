using LibraryApp.Products.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens.BookScreens
{
    class BookIndexScreen : IndexScreen
    {
        public BookIndexScreen(App app) : base(app)
        {
        }

        public override void Run()
        {
            GlobalLibrary glib = GlobalLibrary.GetInstance();

            Console.Clear();
            Console.WriteLine("Title-------------------------Author------------------------ISBN13------------------------STATUS------------------------");


            // TODO: Duplication in BundleIndexScreen, fix it when you have time left.

            int maxTitleLength = 20;
            int maxAuthorLength = 20;
            string sc = "-"; //Spacing character (It's a string, NOT a char)

            List<string> optionList = new List<string>();
            foreach (Book book in glib.Books)
            {
                string title = FieldToSpacedString(book.Title, maxTitleLength, sc);
                string author = FieldToSpacedString(book.Author, maxAuthorLength, sc);
                string isbn13 = FieldToSpacedString(book.Isbn13, 13, sc);
                string availability = FieldToSpacedString(book.GetProductState().StateName, 20, sc);
                optionList.Add($"{title}{author}{isbn13}");
            }

            optionList.Insert(0, "Back");

            string[] options = optionList.ToArray();
            OptionMenu optionMenu = new OptionMenu(options);
            int selectedIndex = optionMenu.Run();

            if (selectedIndex == 0) 
            { 
                App.ChangeScreen(new BookHubScreen(App));
            } else 
            { 
                App.ChangeScreen(new ProductViewScreen(App, glib.Books[selectedIndex-1]));
            }
        }
    }
}
