using LibraryApp.Products.ProductBuilders;
using LibraryApp.Products.ProductFSM;
using LibraryApp.Products.ProductTypes;

namespace LibraryApp
{
    internal class Program
    {
        // TODO: Move this stuff to a different class
        static void Main(string[] args)
        {
            BookBuilder bb = BookBuilder.GetInstance();

            string title = @"  _      _ _                                               
 | |    (_) |                            /\                
 | |     _| |__  _ __ __ _ _ __ _   _   /  \   _ __  _ __  
 | |    | | '_ \| '__/ _` | '__| | | | / /\ \ | '_ \| '_ \ 
 | |____| | |_) | | | (_| | |  | |_| |/ ____ \| |_) | |_) |
 |______|_|_.__/|_|  \__,_|_|   \__, /_/    \_\ .__/| .__/ 
                                 __/ |        | |   | |    
                                |___/         |_|   |_|    
";


            string prompt = title + 
                "\n" +
                "Use the arrow keys to select an option,\nthen press ENTER to confirm\n";
            string[] options = { "Add new book", "Borrow Book", "Return Book", "Exit App" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();
            Console.ReadKey(true);

            switch (selectedIndex)
            {
                case 0:
                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:
                    Console.WriteLine("BYE");
                    Environment.Exit(0);
                    break;

            }


            




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