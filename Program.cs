using LibraryApp.Products.ProductBuilders;
using LibraryApp.Products.ProductFSM;
using LibraryApp.Products.ProductTypes;

namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread process1 = new Thread(() =>
            {
                TestBookBuilder("A");
            });

            Thread process2 = new Thread(() =>
            {
                TestBookBuilder("B");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();

            //BookBuilder bookBuilder = new BookBuilder();
            //bookBuilder
            //    .setTitle("Good Book")
            //    .setAuthor("John Doe")
            //    .setState(new BorrowedState());
            //Book GoodBook = bookBuilder.build();
            //GoodBook.printDetails();
            //GoodBook.borrowProduct();
        }


        public static void TestBookBuilder(string value)
        {
            BookBuilder bookBuilder = BookBuilder.GetInstance(value);
            Console.WriteLine(bookBuilder.Value);
        }
    }
}