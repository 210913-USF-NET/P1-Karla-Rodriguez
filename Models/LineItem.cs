using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class LineItem
    {
      
        public LineItem() { }
        public LineItem(int orId, int prId, int vId, int Quan)
        {
            this.OrderId = orId;
            this.ProductId = prId;
            this.VendorId = vId;
            this.Quantity = Quan;
            
        }

        
        public int Id { get; set; }

        public  int OrderId { get; set; }

        public int ProductId { get; set; }

        public int VendorId { get; set; }

        public int Quantity { get; set; }

    }
        


    }


