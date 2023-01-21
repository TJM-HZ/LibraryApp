using LibraryApp.Screens;
using LibraryApp.Screens.BookScreens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{

    // TODO: Not sure how I feel about this scene system.
    // I chose to do it this way in order to avoid creating a new Screen object every time I switch scenes,
    // but I doubt this is the cleanest implementation.

    class App
    {
        public HomeScreen HomeScreen;

        public BookHubScreen BookHubScreen;
        public BookCreationScreen BookCreationScreen;
        public BookIndexScreen BookIndexScreen;

        private Screen _currentScreen;
        public App()
        {

            HomeScreen= new HomeScreen(this);
            BookHubScreen= new BookHubScreen(this);
            BookCreationScreen= new BookCreationScreen(this);
            BookIndexScreen= new BookIndexScreen(this);

            ChangeScreen(new HomeScreen(this));
        }

        public void ChangeScreen(Screen screen)
        {
            _currentScreen = screen;
            _currentScreen.Run();
        }
    }
}
