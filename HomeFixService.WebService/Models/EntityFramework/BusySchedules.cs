using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFixService.WebService.Models.EntityFramework
{
    //[Serializable]
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

        [NonSerialized]
        private Users _User;

        [ForeignKey("UserId")]
        public virtual Users TheUserThatIsNotAvailableForThesePeriods
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