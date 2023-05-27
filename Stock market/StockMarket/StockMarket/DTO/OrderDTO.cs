namespace StockMarket.DTO
{
    public class OrderDTO
    {
        //public int? ID { get; set; }
        public int StockID { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PersonName { get; set; }
    }
}
