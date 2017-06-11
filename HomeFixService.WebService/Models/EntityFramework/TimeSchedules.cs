using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFixService.WebService.Models.EntityFramework
{
    [Serializable]
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

        [NonSerialized]
        private Users _User;

        [ForeignKey("UserId")]
        public virtual Users TheUserThatWorksOnThisSchedule
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