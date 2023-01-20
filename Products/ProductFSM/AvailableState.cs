using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Products.ProductFSM
{
    class AvailableState : ProductState
    {
        public override void BorrowProduct()
        {
            Console.WriteLine($"Product {this.Product.Title} is now borrowed. Enjoy!");
            this.Product.TransitionTo(new BorrowedState());
        }

        public override void ReturnProduct()
        {
            Console.WriteLine($"Product {this.Product.Title} wasn't borrowed, so it cannot be returned...");
        }
    }
}
