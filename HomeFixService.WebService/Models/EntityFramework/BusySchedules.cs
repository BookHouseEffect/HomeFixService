﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFixService.WebService.Models.EntityFramework
{
    public class BusySchedules : BaseEntity
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BusyPeriodStartOn { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BusyPeriodEndsOn { get; set; }

        [Required]
        [Column(Order = 1), Key]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Users TheUserThatIsNotAvailableForThesePeriods { get; set; }
    }
}