using LibraryApp.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class App
    {

        Screen _currentScreen;
        public App()
        {
            ChangeScreen(new HomeScreen(this));
        }

        public void Start()
        {
            _currentScreen.Run();
        }

        public void ChangeScreen(Screen screen)
        {
            _currentScreen = screen;
        }
    }
}
