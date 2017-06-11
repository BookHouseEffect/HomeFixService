using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFixService.WebService.Models.EntityFramework
{
    [Serializable]
    public class Ratings : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.DateTime)]
        public DateTime FeedbackDateTime { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 5)]
        public int FeedbackPoints { get; set; }

        [Required]
        [Column(Order =1), Key]
        public int UserId { get; set; }

        [NonSerialized]
        private Users _User;

        [ForeignKey("UserId")]
        public virtual Users TheRatedUser
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