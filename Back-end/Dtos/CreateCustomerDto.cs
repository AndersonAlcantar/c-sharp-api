using System.ComponentModel.DataAnnotations;

namespace Back_end.Dtos
{
    public class CreateCustomerDto
    {
        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Last name field is required ")]
        public string LastName { get; set; }

        public string Phone { get; set; }

        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Email field is not correct")]
        public string Email { get; set; }
    }
}
