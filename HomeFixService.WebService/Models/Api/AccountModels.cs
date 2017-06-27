using HomeFixService.WebService.Models.Enums;
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

    public class ProfessionModel
    {
        [Required]
        public ProfessionsEnum ProfessionToAssign { get; set; }
    }

    public class ProfessionServiceModel
    { 
        [Required(AllowEmptyStrings = false)]
        public string ServiceName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ServiceUnit { get; set; }

        [Required]
        public float ServiceUnitPrice { get; set; }

        [Required]
        public CurrencyEnum Currency { get; set; }

    }

    public class AddProfessionServiceModel : ProfessionServiceModel
    {
        [Required]
        public int UserProfessionId { get; set; }
    }

    public class RateModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 5)]
        public int Points { get; set; }
    }
}