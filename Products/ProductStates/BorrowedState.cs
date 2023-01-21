using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Products.ProductFSM
{
    class BorrowedState : ProductState
    {
        public override void BorrowProduct()
        {
            Console.WriteLine($"Sorry, {this.Product.GetType()} {this.Product.Title} has already been borrowed...");
        }

        public override void ReturnProduct()
        {
            Console.WriteLine($"Product {this.Product.Title} returned. Thank you!");
            this.Product.TransitionTo(new AvailableState());
        }
    }
}
