using HomeFixService.WebService.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeFixService.WebService.Models.EntityFramework
{
    public class UserProfessions
    {
        [Required]
        [Column(Order =0), Key]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Users TheUser { get; set; }

        [Required]
        public Professions TheProfession { get; set; }
    }
}