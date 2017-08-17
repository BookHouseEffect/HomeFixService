using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFixService.WebService.Models.EntityFramework
{
    //[Serializable]
    public class ProfessionServices : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string ServiceName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ServiceUnit { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float ServiceUnitPrice { get; set; }

        [Required]
        public int ServiceUnitId { get; set; }

        [ForeignKey("ServiceUnitId")]
        public Currencies TheCurrencyUsed { get; set; }

        [Required]
        [Column(Order = 1), Key, ForeignKey("TheProfessionForThisService")]
        public int UserProfessionId { get; set; }

        [Required]
        [Column(Order = 2), Key, ForeignKey("TheProfessionForThisService")]
        public int UserId { get; set; }

        [NonSerialized]
        private UserProfessions _Profession;

        public virtual UserProfessions TheProfessionForThisService
        {
            get
            {
                return _Profession;
            }
            set
            {
                _Profession = value;
            }
        }
    }
}