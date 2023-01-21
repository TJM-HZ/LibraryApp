using LibraryApp.Products.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens.BookScreens
{
    class BookIndexScreen : Screen
    {
        public BookIndexScreen(App app) : base(app)
        {
        }

        public override void Run()
        {
            GlobalLibrary glib = GlobalLibrary.GetInstance();

            Console.Clear();
            Console.WriteLine("Title-------------------------Author------------------------ISBN10------------------------ISBN13------------------------");

            int maxTitleLength = 20;
            int maxAuthorLength = 20;
            string sc = "-"; //Spacing character (It's a string, NOT a char)
            List<string> optionList = new List<string>();
            foreach (Book book in glib.Books)
            {
                string title = FieldToSpacedString(book.Title, maxTitleLength, sc);
                string author = FieldToSpacedString(book.Author, maxAuthorLength, sc);
                string isbn10 = FieldToSpacedString(book.Isbn10, 10, sc);
                string isbn13 = FieldToSpacedString(book.Isbn13, 13, sc);

                optionList.Add($"{title}{author}{isbn10}{isbn13}");
            }

            string[] options = optionList.ToArray();
            OptionMenu optionMenu = new OptionMenu(options);
            int selectedIndex = optionMenu.Run();
        }

        private string FieldToSpacedString(string field, int maxLength, string spacingCharacter)
        {
            string convertedField = field;
            if (field.Length > maxLength)
            {
                convertedField = field.Substring(0, maxLength) + "...";
            }
            int spacingNeeded = 30 - convertedField.Length; //TODO: Remove magic number here.
            string spacing = "";
            for (int i = 0; i < spacingNeeded; i++)
            {
                spacing += spacingCharacter;
            }
            convertedField += spacing;

            return convertedField;
        }
    }
}
