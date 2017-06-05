using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFixService.WebService.Models.EntityFramework
{
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
        [Column(Order = 1), Key, ForeignKey("TheProfessionForThisService")]
        public int UserProfessionId { get; set; }

        [Required]
        [Column(Order = 2), Key, ForeignKey("TheProfessionForThisService")]
        public int UserId { get; set; }

        public virtual UserProfessions TheProfessionForThisService { get; set; }

        //TODO Add currency type enum (MKD, Euro, USD, etc...)
    }
}