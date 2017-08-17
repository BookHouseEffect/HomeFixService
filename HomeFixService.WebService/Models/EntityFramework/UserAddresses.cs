using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFixService.WebService.Models.EntityFramework
{
    //[Serializable]
    public class UserAddresses : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public String StreetName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public String City { get; set; }

        [Required(AllowEmptyStrings = false)]
        public String Country { get; set; }

        [Required]
        [Range(minimum: -90.0, maximum: 90.0)]
        public float Latitude { get; set; }

        [Required]
        [Range(minimum: -180.0, maximum: 180.0)]
        public float Longitude { get; set; }

        [Required]
        [Column(Order = 1), Key]
        public int UserId { get; set; }

        [NonSerialized]
        private Users _User; 

        [ForeignKey("UserId")]
        public virtual Users TheUserLivingOnThisAddress
        {
            get
            {
                return _User;
            }
            set
            {
                _User = value;
            }
        }
    }
}