using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeFixService.WebService.Models.EntityFramework
{
    public class Users : BaseEntity
    {
        [Required(AllowEmptyStrings =false)]
        public string UserFirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string UserLastName { get; set; }

        public virtual List<Contact> TheContactsForThisUser { get; set; }

        public virtual List<Ratings> RatingsGivenForThisUser { get; set; }

        public virtual List<UserAddresses> AddressesThatThisUserLivesOn { get; set; }

        public virtual List<UserProfessions> ProfessionsThatThisUserKnows { get; set; }

        public virtual List<Services> ServicesThatThisUserOffers { get; set; }

        public virtual List<TimeSchedules> TimeScheduleForThisUser { get; set; }

        public virtual List<BusySchedules> BusyScheduleForThisUser { get; set; }
    }
}