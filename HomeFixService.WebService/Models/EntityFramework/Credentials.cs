using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFixService.WebService.Models.EntityFramework
{
    [Serializable]
    public class Credentials : BaseEntity
    {
        [Required]
        [Index("UniqueUserNameIndex", IsUnique = true)]
        [MaxLength(128)]
        public string UserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string PasswordSalt { get; set; }

        [Required]
        [Column(Order = 1), Key]
        public int UserId { get; set; }

        [NonSerialized]
        private Users _User;

        [ForeignKey("UserId")]
        public virtual Users TheUserForThisCredential
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

        [NonSerialized]
        private List<UserPasswordsHistory> _History;

        public virtual List<UserPasswordsHistory> TheHistoryForTheseCredentials
        {
            get
            {
                return _History;
            }
            set
            {
                _History = value;
            }
        }
    }
}