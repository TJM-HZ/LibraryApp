using LibraryApp.Products.ProductBuilders;
using LibraryApp.Products.ProductTypes;
using LibraryApp.Screens.BookScreens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens.BundleScreens
{
    internal class BundleCreationScreen : CreationScreen
    {
        public BundleCreationScreen(App app, Screen previousScreen) : base(app, previousScreen)
        {
        }

        public override void Run()
        {
            BookBuilder bb = BookBuilder.GetInstance();
            GlobalLibrary glib = GlobalLibrary.GetInstance();

            Console.Clear();
            Console.WriteLine("Creating a new bundle");
            Console.Write($"Fields marked with ");
            requiredSuffix();
            Console.Write(" are required\n");

            glib.addBundle(new ProductBundle(StringField("Name", true)));

            Console.Clear();
            Console.WriteLine($"New bundle {glib.Bundles.Last().Title} added to the library");

            Console.WriteLine("Press any key to go back to the Bundle Hub");
            Console.ReadKey();
            App.ChangeScreen(PreviousScreen);
        }
    }
}
