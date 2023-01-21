using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens.BookScreens
{   
    class BookIndexScreen : Screen
    {
        public BookIndexScreen(App app) : base(app)
        {
        }

        public override void Run()
        {
            Console.Clear();
            Console.WriteLine("Title-------------------------Author-------------------------ISBN10-------------------------ISBN13");
            string[] options = { };
            

        }
    }
}
