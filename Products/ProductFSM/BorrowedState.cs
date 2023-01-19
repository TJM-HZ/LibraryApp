using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Products.ProductFSM
{
    class BorrowedState : ProductState
    {
        public override void borrowProduct()
        {
            Console.WriteLine("Product was already borrowed. Sorry.");
        }

        public override void returnProduct()
        {
            Console.WriteLine("Product returned. Thank you!");
        }
    }
}
