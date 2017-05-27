using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeFixService.WebService.Models.EntityFramework
{
    public class Services : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string ServiceName { get; set; }

        [Required(AllowEmptyStrings =false)]
        public string ServiceUnit { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float ServiceUnitPrice { get; set; }

        [Required]
        [Column(Order = 1), Key]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Users TheUserServing { get; set; }

        //TODO Add currency type enum (MKD, Euro, USD, etc...)
    }
}