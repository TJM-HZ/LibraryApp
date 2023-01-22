using LibraryApp.Screens;
using LibraryApp.Screens.BookScreens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class App
    {
        private Screen _currentScreen;
        public App()
        {
            ChangeScreen(new HomeScreen(this));
        }

        public void ChangeScreen(Screen screen)
        {
            _currentScreen = screen;
            _currentScreen.Run();
        }
    }
}
