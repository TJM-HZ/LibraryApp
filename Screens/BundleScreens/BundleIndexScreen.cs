using LibraryApp.Products.ProductTypes;
using LibraryApp.Screens.BookScreens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens.BundleScreens
{
    class BundleIndexScreen : IndexScreen
    {
        public BundleIndexScreen(App app) : base(app) { }

        public override void Run()
        {
            GlobalLibrary glib = GlobalLibrary.GetInstance();

            Console.Clear();
            Console.WriteLine("Bundle name-------------------Amount of products------------------------------------------------------------------------");

            int maxTitleLength = 20;
            string sc = "-"; //Spacing character (It's a string, NOT a char)

            List<string> optionList = new List<string>();
            foreach (ProductBundle bundle in glib.Bundles)
            {
                string title = FieldToSpacedString(bundle.Title, maxTitleLength, sc);
                string amountString = FieldToSpacedString(bundle.Length().ToString(), maxTitleLength, sc+sc+sc); //TODO: This look kinda bad

                optionList.Add($"{title}{amountString}");
            }

            optionList.Insert(0, "Back");

            string[] options = optionList.ToArray();
            OptionMenu optionMenu = new OptionMenu(options);
            int selectedIndex = optionMenu.Run();

            if (selectedIndex == 0)
            {
                App.ChangeScreen(new BundleHubScreen(App));
            }
            else
            {
                App.ChangeScreen(new ProductViewScreen(App, glib.Bundles[selectedIndex - 1]));
            }
        }
    }
}
