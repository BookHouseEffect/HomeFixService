using HomeFixService.WebService.Models.Enums;
using System.ComponentModel.DataAnnotations;
using HomeFixService.WebService.Extensions;
using System;

namespace HomeFixService.WebService.Models.EntityFramework
{
    //[Serializable]
    public class Professions : BaseEnumEntity
    {  
        [Required, MaxLength(100)]
        public string ProfessionName { get; set; }

        [MaxLength(100)]
        public string ProfessionDescription { get; set; }

        protected Professions() { } //For EF

        private Professions(ProfessionsEnum @enum)
        {
            this.Id = (int)@enum;
            this.ProfessionName = @enum.ToString();
            this.ProfessionDescription = @enum.GetEnumDescription();
        }

        public static implicit operator Professions(ProfessionsEnum @enum) 
            => new Professions(@enum);

        public static implicit operator ProfessionsEnum(Professions profession) 
            => (ProfessionsEnum)profession.Id;
    }
}