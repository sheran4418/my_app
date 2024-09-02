using My_Api.Models;

namespace My_Api.Dtos.OrderHeader
{
    public class UpdateOrderHeaderDto
    {
        public string user_id { get; set; } = string.Empty;
        public string date { get; set; } = DateTime.Now.ToShortDateString();
        public string Headerstate { get; set; } = string.Empty;
        //public ICollection<OrderLine> orderLines { get; set; }
    }
}
