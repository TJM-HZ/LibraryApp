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

            Book book1 = bb
                .setTitle("funbook")
                .setAuthor("A funny person")
                .build();
            Book book2 = bb
                .setTitle("booker2")
                .setAuthor("A writer of books")
                .build();

            ProductBundle bundle1 = new ProductBundle("Big Bundle");
            bundle1.Add(book1);
            bundle1.Add(book2);

            bundle1.printDetails();

            bundle1.Remove(book1);

            bundle1.printDetails();
        }
    }
}