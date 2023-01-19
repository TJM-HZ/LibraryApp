using LibraryApp.Products.ProductBuilders;
using LibraryApp.Products.ProductFSM;
using LibraryApp.Products.ProductTypes;

namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookBuilder bookBuilder = BookBuilder.GetInstance();
            bookBuilder
                .setTitle("Good Book")
                .setAuthor("John Doe")
                .setState(new BorrowedState());
            Book GoodBook = bookBuilder.build();
            GoodBook.printDetails();
            GoodBook.borrowProduct();
        }
    }
}