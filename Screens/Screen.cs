using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens
{
    abstract class Screen
    {
        protected App App;
        protected Screen PreviousScreen;

        public Screen(App app)
        {
            App = app;
            PreviousScreen = null;
        }

        public Screen(App app, Screen previousScreen)
        {
            App = app;
            PreviousScreen = previousScreen;
        }

        virtual public void Run()
        {
            // Runs the logic of the screen
        }
    }
}
