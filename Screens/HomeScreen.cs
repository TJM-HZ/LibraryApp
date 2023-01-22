using LibraryApp.Screens.BookScreens;
using LibraryApp.Screens.BundleScreens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens
{
    class HomeScreen : Screen
    {
        public HomeScreen(App app) : base(app){}

        public override void Run()
        {
            Console.Clear();
            Console.WriteLine(@"
  _      _ _                                               
 | |    (_) |                            /\                
 | |     _| |__  _ __ __ _ _ __ _   _   /  \   _ __  _ __  
 | |    | | '_ \| '__/ _` | '__| | | | / /\ \ | '_ \| '_ \ 
 | |____| | |_) | | | (_| | |  | |_| |/ ____ \| |_) | |_) |
 |______|_|_.__/|_|  \__,_|_|   \__, /_/    \_\ .__/| .__/ 
                                 __/ |        | |   | |    
                                |___/         |_|   |_|    


");
            Console.WriteLine("Use the up and down arrow keys to navigate the menus and press ENTER to select an option");
            string[] options = { "Manage Books", "Manage Bundles", "Exit App" };
            OptionMenu optionMenu = new OptionMenu(options);
            int selectedIndex = optionMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    App.ChangeScreen(new BookHubScreen(App));
                    break;
                case 1:
                    App.ChangeScreen(new BundleHubScreen(App));
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
            
        }
    }
}
