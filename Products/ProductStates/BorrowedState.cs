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

        public override void BorrowProduct()
        {
        }

        public override void ReturnProduct()
        {
            this.Product.TransitionTo(new AvailableState());
        }
    }
}
