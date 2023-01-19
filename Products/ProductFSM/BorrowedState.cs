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
            Console.WriteLine($"Sorry, {this.product.GetType()} {this.product.Title} has already been borrowed...");
        }

        public override void returnProduct()
        {
            Console.WriteLine($"Product {this.product.Title} returned. Thank you!");
            this.product.transitionTo(new AvailableState());
        }
    }
}
