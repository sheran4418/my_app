namespace My_Api.Dtos.OrderLine
{
    public class UpdateLineDto
    {
        public int product_id { get; set; }
        public int qty { get; set; }
        public int price { get; set; }
        public string Linestate { get; set; } = string.Empty;
        public int? headerId { get; set; }

    }
}
