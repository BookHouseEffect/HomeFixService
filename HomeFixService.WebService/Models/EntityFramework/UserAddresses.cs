using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFixService.WebService.Models.EntityFramework
{
    public class UserAddresses : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public String StreetName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public String City { get; set; }

        [Required(AllowEmptyStrings = false)]
        public String Country { get; set; }

        [Required]
        [Column(Order = 1), Key]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Users TheUserLivingOnThisAddress { get; set; }
    }
}