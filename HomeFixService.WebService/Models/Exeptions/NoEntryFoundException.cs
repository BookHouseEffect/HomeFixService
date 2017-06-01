using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeFixService.WebService.Models.Exeptions
{
    public class NoEntryFoundException : Exception
    {
        public int Id { get; }
        public int UserId { get; }
        public string ExceptionInTable { get; }

        public NoEntryFoundException(int id, string exceptionInTable)
            :base(
                 String.Format(
                     "No entry with the key {0} found from {1} table.",
                     id, 
                     exceptionInTable)
                 )
        {
            this.Id = id;
            this.ExceptionInTable = exceptionInTable;
        }

        public NoEntryFoundException(int id, int userId, string exceptionInTable)
            : base(
                 String.Format(
                     "No entry with the key {0} for user with id {1} found from {2} table.",
                     id,
                     userId,
                     exceptionInTable)
                 )
        {
            this.Id = id;
            this.UserId = userId;
            this.ExceptionInTable = exceptionInTable;
        }

    }
}