using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens.BookScreens
{
    class BookHubScreen : Screen
    {
        public BookHubScreen(App app, Screen previousScreen) : base(app, previousScreen) { }

        public override void Run()
        {
            Console.Clear();
            string[] options = { "Add New Book", "View All Books", "Back" };
            OptionMenu optionMenu = new OptionMenu(options);
            int selectedIndex = optionMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    App.ChangeScreen(new BookCreationScreen(App, this));
                    break;
                case 1:
                    App.ChangeScreen(new BookIndexScreen(App, this));
                    break;
                case 2:
                    App.ChangeScreen(PreviousScreen);
                    break;
            }

        }
    }
}
