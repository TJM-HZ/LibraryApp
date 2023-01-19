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
            Console.WriteLine($"Product {this.product.Title} is now borrowed. Enjoy!");
            this.product.transitionTo(new BorrowedState());
        }

        public override void returnProduct()
        {
            Console.WriteLine($"Product {this.product.Title} wasn't borrowed, so it cannot be returned...");
        }
    }
}
