using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class LineItem
    {
      
        [Key]
        public int LineItemId { get; set; }

        public  int OrderId { get; set; }

        public int ProductId { get; set; }

        public int VendorId { get; set; }

        public int Quantity { get; set; }

    }
        


    }


