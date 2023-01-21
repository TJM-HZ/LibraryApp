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

            string[] options = { "Manage Books", "Manage Bundles", "Exit App" };
            OptionMenu optionMenu = new OptionMenu(options);
            int selectedIndex = optionMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("OPTION 0 SELECTED");
                    break;
                case 1:
                    Console.WriteLine("OPTION 1 SELECTED");
                    break;
                case 2:
                    Console.WriteLine("OPTION 2 SELECTED");
                    break;
            }
            
        }
    }
}
