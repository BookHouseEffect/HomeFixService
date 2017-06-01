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

        public virtual List<Contacts> TheContactsForThisUser { get; set; }

        public virtual List<Ratings> TheRatingsGivenForThisUser { get; set; }

        public virtual List<UserAddresses> TheAddressesThatThisUserWorksOn { get; set; }

        public virtual List<UserProfessions> TheProfessionsThatThisUserKnows { get; set; }

        public virtual List<ProfessionServices> TheServicesThatThisUserOffers { get; set; }

        public virtual List<TimeSchedules> TheTimeScheduleForThisUser { get; set; }

        public virtual List<BusySchedules> TheBusyScheduleForThisUser { get; set; }
    }
}