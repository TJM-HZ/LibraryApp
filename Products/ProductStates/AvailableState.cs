using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Products.ProductFSM
{
    class AvailableState : ProductState
    {

        public AvailableState() {
            this.stateName = "Available";
        }

        public override string BorrowProduct()
        {
            this.Product.TransitionTo(new BorrowedState());
            return $"Product {this.Product.Title} is now borrowed. Enjoy!";
        }

        public override string ReturnProduct()
        {
            return $"Product {this.Product.Title} wasn't borrowed, so it cannot be returned...";
        }
    }
}
