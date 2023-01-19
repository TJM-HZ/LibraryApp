using LibraryApp.Products.ProductFSM;
using LibraryApp.Products.ProductTypes;

namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("1984", new AvailableState(), null, null, null, null, null, null, null, null, null);
            Film film1 = new Film("Batman", new BorrowedState(), null, null, null, null, null, null, null, null, null, null, null, null);

            film1.borrowProduct();

        }
    }
}