using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace My_Api.Models
{
    public class OrderHeader
    {
        [Key]
        public int ord_id { get; set; }
        public string user_id { get; set; } = string.Empty;
        public string date { get; set; } = DateTime.Now.ToShortDateString();
        public string Headerstate { get; set; } = string.Empty;
        public List<OrderLine> orderLines { get; set; } = new List<OrderLine>();

    }
}
