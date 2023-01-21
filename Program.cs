using LibraryApp.Menus;
using LibraryApp.Products;
using LibraryApp.Products.ProductBuilders;
using LibraryApp.Products.ProductFSM;
using LibraryApp.Products.ProductTypes;

namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookBuilder bb = BookBuilder.GetInstance();
            GlobalLibrary glib = GlobalLibrary.GetInstance();

            // TitleScreen

            // AddBookScreen - Screen for adding a new book
            // IndexBooksScreen - Screen for showing all books
            // ViewBookScreen - Screen for a selected book (printDetails etc.)

            // AddBundleScreen - Screen for adding a new bundle
            // IndexBundleScreen - Screen for showing all bundles
            // ViewBundleScreen - Screen for a selected bundle (Shows an index of books in the bundle)


            CreateBookMenu cbMenu = new CreateBookMenu(bb, glib);

        }
    }
}