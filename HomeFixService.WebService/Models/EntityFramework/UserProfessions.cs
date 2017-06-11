using HomeFixService.WebService.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFixService.WebService.Models.EntityFramework
{
    [Serializable]
    public class UserProfessions : BaseEntity
    {
        [Required]
        [Column(Order =1), Key]
        public int UserId { get; set; }

        [Required]
        public Professions TheProfession { get; set; }

        [NonSerialized]
        private Users _User;

        [ForeignKey("UserId")]
        public virtual Users TheUser
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