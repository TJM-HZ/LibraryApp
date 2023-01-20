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
                .SetTitle("funbook")
                .SetAuthor("A funny person")
                .Build();
            Book book2 = bb
                .SetTitle("booker2")
                .SetAuthor("A writer of books")
                .Build();

            ProductBundle bundle1 = new ProductBundle("Big Bundle");
            bundle1.Add(book1);
            bundle1.Add(book2);

            bundle1.PrintDetails();

            bundle1.Remove(book1);

            bundle1.PrintDetails();
        }
    }
}