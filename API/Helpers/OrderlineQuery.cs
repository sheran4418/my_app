namespace My_Api.Helpers
{
    public class OrderlineQuery
    {
     
        public string? orderId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 1;
    }
}
