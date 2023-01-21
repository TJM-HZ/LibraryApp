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

            CreateBookMenu cbMenu = new CreateBookMenu(bb, glib);

        }
    }
}