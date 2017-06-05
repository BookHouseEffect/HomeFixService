using HomeFixService.WebService.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFixService.WebService.Models.EntityFramework
{
    public class UserProfessions : BaseEntity
    {
        [Required]
        [Column(Order =1), Key]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Users TheUser { get; set; }

        [Required]
        public Professions TheProfession { get; set; }
    }
}