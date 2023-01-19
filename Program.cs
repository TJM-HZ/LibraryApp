using LibraryApp.Products.ProductFSM;
using LibraryApp.Products.ProductTypes;

namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("LOTR", "500", "English", "Tolkien", "NoIdea", null, "Fantasy", "0000000000", "000-0000000000", new AvailableState());
            book1.borrowProduct();
            book1.borrowProduct();
            book1.returnProduct();
            book1.returnProduct();
        }
    }
}