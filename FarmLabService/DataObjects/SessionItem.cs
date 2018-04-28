using System;
using System.ComponentModel.DataAnnotations;

namespace FarmLabService.DataObjects
{
    public class SessionItem
    {
        [Key]
        public int Id { get; set; }
        public DateTime LastActivity { get; set; }
        public bool IsValid { get; set; }
        public Guid SessionKey { get; set; }

        [Required]
        public UserItem User { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
