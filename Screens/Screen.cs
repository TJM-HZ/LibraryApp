using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens
{
    abstract class Screen
    {
        protected App App;

        public Screen(App app)
        {
            App = app;
        }

        virtual public void Run()
        {
            // Runs the logic of the screen
        }
    }
}
