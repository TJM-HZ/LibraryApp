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


            string prompt = 
                "LIBRARY APP\n" +
                "------------------------\n" +
                "Select an option with the arrow keys and press ENTER";
            string[] options = { "Add new book", "Borrow Book", "Return Book" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();
            Console.ReadKey(true);



            




            // TODO: There's probably a better way of making an interactive system,
            // but this is all I could come up with in the short amount of time I have available.

            //Console.WriteLine("LIBRARY APP");
            //Console.WriteLine("------------------------\n");

            //Console.WriteLine("Type in a number and press ENTER to select an option\n");
            //Console.WriteLine("1. Add a new book");
            //Console.WriteLine("2. Borrow a book");
            //Console.WriteLine("3. Return a book");
            //Console.Write("OPTION: ");
        }
    }
}