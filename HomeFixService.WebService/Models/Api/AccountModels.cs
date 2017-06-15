using System.ComponentModel.DataAnnotations;

namespace HomeFixService.WebService.Models.Api
{
    public class RegisterModel
    {
        [Required(AllowEmptyStrings =false)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class PhoneModel
    {
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }
    }

    public class AddressModel
    {
        [Required(AllowEmptyStrings = false)]
        public string StreetName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Country { get; set; }
    }

}