using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeFixService.WebService.Models.EntityFramework
{
    //[Serializable]
    public class Users : BaseEntity
    {
        [Required(AllowEmptyStrings =false)]
        public string UserFirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string UserLastName { get; set; }

        public long RatingSum { get; set; }

        public int RatingCount { get; set; }

        [NonSerialized]
        private List<Contacts> _Contacts;

        [JsonIgnore]
        public virtual List<Contacts> TheContactsForThisUser
        {
            get
            {
                return _Contacts;
            }
            set
            {
                _Contacts = value;
            }
        }

        [NonSerialized]
        private List<Ratings> _Rating;

        [JsonIgnore]
        public virtual List<Ratings> TheRatingsGivenForThisUser
        {
            get
            {
                return _Rating;
            }
            set
            {
                _Rating = value;
            }
        }

        [NonSerialized]
        private List<UserAddresses> _Address;

        [JsonIgnore]
        public virtual List<UserAddresses> TheAddressesThatThisUserWorksOn
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }

        [NonSerialized]
        private List<UserProfessions> _Profession;

        [JsonIgnore]
        public virtual List<UserProfessions> TheProfessionsThatThisUserKnows
        {
            get
            {
                return _Profession;
            }
            set
            {
                _Profession = value;
            }
        }

        [NonSerialized]
        private List<TimeSchedules> _Time;

        [JsonIgnore]
        public virtual List<TimeSchedules> TheTimeScheduleForThisUser
        {
            get
            {
                return _Time;
            }
            set
            {
                _Time = value;
            }
        }

        [NonSerialized]
        private List<BusySchedules> _Busy;

        [JsonIgnore]
        public virtual List<BusySchedules> TheBusyScheduleForThisUser
        {
            get
            {
                return _Busy;
            }
            set
            {
                _Busy = value;
            }
        }
    }
}