using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class LineItem
    {

       
            public LineItem() { }
            public LineItem(int orId, int prId, int vId, int Quan)
            {
                this.OrdersId = orId;
                this.ProductsId = prId;
                this.VendorBranchesId = vId;
                this.Quantity = Quan;

            }


            public int Id { get; set; }

            public int OrdersId { get; set; }

            public int ProductsId { get; set; }

            public int VendorBranchesId { get; set; }

            public int Quantity { get; set; }

        }



    }


