namespace Models
{
    public class LineItem
    {

    public LineItem() {}
        public LineItem(int OrdersId, int ProductsId, int Quantity)
        {
            this.OrderId = OrderId;
            this.ProductId = ProductId;

        }
        public Orders OrderId {get; set;} 

        public Products ProductId {get; set;}

    public int Quantity {get; set;}

    public override string ToString()
        {
            return $"OrderId: {this.OrderId}, Purchase: {this.ProductId}, Remaining: {this.Quantity}";
        }
    }


}