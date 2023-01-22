using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Products.ProductFSM
{
    class BorrowedState : ProductState
    {
        public BorrowedState()
        {
            this.StateName = "Borrowed";
        }

        public override string BorrowProduct()
        {
            return $"Sorry, {this.Product.Title} has already been borrowed.";
        }

        public override string ReturnProduct()
        {
            this.Product.TransitionTo(new AvailableState());
            return $"{this.Product.Title} returned to library.";
        }
    }
}
