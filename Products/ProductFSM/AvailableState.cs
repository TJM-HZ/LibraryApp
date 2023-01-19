using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Products.ProductFSM
{
    class AvailableState : ProductState
    {
        public override void borrowProduct()
        {
            Console.WriteLine("Product borrowed. Enjoy!");
        }

        public override void returnProduct()
        {
            Console.WriteLine("This product wasn't borrowed, so you can't return it...");
        }
    }
}
