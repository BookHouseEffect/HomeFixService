using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeFixService.WebService.Models.EntityFramework
{
    public class TimeSchedules : BaseEntity
    {
        [Required]
        public DayOfWeek WorkingDayOfWeek { get; set; }

        [Required]
        [DataType(DataType.Time)]
        //[Timestamp]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        //[Timestamp]
        public TimeSpan EndTime { get; set; }

        [Required]
        [Column(Order = 1), Key]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Users TheUserThatWorksOnThisSchedule { get; set; }
    }
}