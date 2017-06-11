﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFixService.WebService.Models.EntityFramework
{
    [Serializable]
    public class UserPasswordsHistory : BaseEntity
    {
        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string PasswordSalt { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ExpiredOn { get; set; }

        [Required]
        [Column(Order = 1), Key, ForeignKey("TheCredentialForThisHistory")]
        public int CredentialsId { get; set; }

        [Required]
        [Column(Order = 2), Key, ForeignKey("TheCredentialForThisHistory")]
        public int UserId { get; set; }

        [NonSerialized]
        private Credentials _Credential;

        public virtual Credentials TheCredentialForThisHistory
        {
            get
            {
                return _Credential;
            }
            set
            {
                _Credential = value;
            }
        }

    }
}