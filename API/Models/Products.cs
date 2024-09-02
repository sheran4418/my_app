using System.ComponentModel.DataAnnotations;

namespace My_Api.Models
{
    public class Products
    {
        [Key]
        public int prod_id { get; set; }
        public string prod_code { get; set; } = string.Empty;
        public string prod_name { get; set; } = string.Empty;
        public string prod_description { get; set; } = string.Empty;
        public int prod_qty { get; set; }
        public string prod_status { get; set; } = string.Empty;
        public int prod_price { get; set; }
        public string prod_dateAdded { get; set; } = DateTime.Now.ToShortDateString();

    }
}
