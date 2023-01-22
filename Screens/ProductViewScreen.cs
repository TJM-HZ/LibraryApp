using LibraryApp.Products;
using LibraryApp.Products.ProductTypes;
using LibraryApp.Screens.BookScreens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens
{
    class ProductViewScreen : Screen
    {
        protected Product _product;
        protected string _stateMsg;
          
        public ProductViewScreen(App app, Product product, Screen previousScreen) : base(app)
        {
            _product = product;
            _stateMsg = "";
            PreviousScreen = previousScreen;
        }

        public override void Run()
        {
            Console.Clear();

            
            if ( _product is ProductBundle) {
                _product.PrintDetails(false);
            } else
            {
                _product.PrintDetails(true);
            }

            Console.WriteLine();

            string[] options = { "Mark product as borrowed", "Mark product as returned", "Back" };
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
                    App.ChangeScreen(PreviousScreen);
                    break;
            }
        }
    }
}
