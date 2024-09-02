using System.ComponentModel.DataAnnotations;

namespace My_Api.Models
{
    public class OrderLine
    {
        [Key]
        public int ordLine_id { get; set; }
        public int product_id { get; set; }
        public int qty { get; set; }
        public int price { get; set; }
        public string Linestate { get; set; } = string.Empty;
        public int? headerId { get; set; }
        public OrderHeader? OrderHeader { get; set; }


    }
}
