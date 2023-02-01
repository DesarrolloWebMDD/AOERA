using System;
using Domain.Core.Entity;

namespace Domain.MainModule.Entity
{
    public class LogSessionUser : Entity<int>
    {
        public int UserId { get; set; }
        public string Platform { get; set; }
        public DateTime LoginDate { get; set; }

        public Usuario User { get; set; }
    }
}