using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFixService.WebService.Models.EntityFramework
{
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

        [ForeignKey("UserId")]
        public virtual Users TheRatedUser { get; set; }
    }
}