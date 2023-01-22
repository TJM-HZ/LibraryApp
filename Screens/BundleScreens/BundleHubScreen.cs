using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens.BundleScreens
{
    class BundleHubScreen : Screen
    {
        public BundleHubScreen(App app) : base(app) { }

        public override void Run()
        {
            Console.Clear();
            string[] options = { "Add New Bundle", "View All Bundles", "Back" };
            OptionMenu optionMenu = new OptionMenu(options);
            int selectedIndex = optionMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    App.ChangeScreen(new BundleCreationScreen(App));
                    break;
                case 1:
                    //App.ChangeScreen(new BundleIndexScreen(App));
                    break;
                case 2:
                    App.ChangeScreen(new HomeScreen(App));
                    break;
            }

        }
    }
}
