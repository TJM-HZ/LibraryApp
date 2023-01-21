using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens
{
    class BookHubScreen : Screen
    {
        public BookHubScreen(App app) : base(app){}

        public override void Run()
        {
            Console.Clear();
            string[] options = { "Add New Book", "View All Books", "Back" };
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
                    new HomeScreen(this.App).Run();
                    break;
            }
            
        }
    }
}
