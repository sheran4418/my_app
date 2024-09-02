using System.ComponentModel.DataAnnotations;

namespace My_Api.Models
{
    public class Users
    {
        [Key]
        public int user_id { get; set; }
        public string u_name { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string u_password { get; set; } = string.Empty;
        public string u_email { get; set; } = string.Empty;
        public string u_fname { get; set; } = string.Empty;
        public string u_lname { get; set; } = string.Empty;
        public string u_isactive { get; set; } = string.Empty;
    }
}
