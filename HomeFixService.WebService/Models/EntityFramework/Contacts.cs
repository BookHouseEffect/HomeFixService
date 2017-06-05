using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFixService.WebService.Models.EntityFramework
{
    public class Contacts : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [Column(Order = 1), Key]
        public int UserId { get; set; }

        [ForeignKey("UserId")]  
        public virtual Users ThePhoneOwner { get; set; }
    }
}