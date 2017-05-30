using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeFixService.WebService.Services.Exeptions
{
    public class NoEntryFoundException : Exception
    {
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
            this.UserId = id;
            this.ExceptionInTable = exceptionInTable;
        }

    }
}