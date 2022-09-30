using System.ComponentModel.DataAnnotations;

namespace Back_end.Dtos
{
    public class CreateCustomerDto
    {
        [Required(ErrorMessage = "Name field is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Last name field is required ")]
        public string lastName { get; set; }

        public string phone { get; set; }

        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Email field is not correct")]
        public string email { get; set; }

        [Required(ErrorMessage = "Address field is required ")]
        public string address { get; set; }
    }
}
