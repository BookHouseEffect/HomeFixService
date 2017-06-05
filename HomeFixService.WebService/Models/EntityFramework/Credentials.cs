using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFixService.WebService.Models.EntityFramework
{
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

        [ForeignKey("UserId")]
        public virtual Users UserForThisCredential { get; set; }

        public virtual List<UserPasswordsHistory> TheHistoryForTheseCredentials { get; set; }
    }
}