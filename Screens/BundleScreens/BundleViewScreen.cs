using LibraryApp.Products;
using LibraryApp.Screens.BookScreens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens.BundleScreens
{
    class BundleViewScreen : ProductViewScreen
    {
        public BundleViewScreen(App app, Product product) : base(app, product)
        {
        }

        public override void Run()
        {
            Console.Clear();

            _product.PrintDetails(false);

            string[] options = { "Mark products as borrowed", "Mark product as returned", "Back" };
            OptionMenu optionMenu = new OptionMenu(options);
            int selectedIndex = optionMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Run();
                    break;
                case 1:
                    Run();
                    break;
                case 2:
                    App.ChangeScreen(new BundleIndexScreen(App));
                    break;
            }
        }
    }
}
