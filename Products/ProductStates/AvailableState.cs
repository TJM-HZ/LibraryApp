using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Products.ProductFSM
{
    class AvailableState : ProductState
    {

        public AvailableState() 
        {
            this.StateName = "Available";
        }

        public override void BorrowProduct()
        {
            this.Product.TransitionTo(new BorrowedState());
        }

        public override void ReturnProduct()
        {
        }
    }
}
