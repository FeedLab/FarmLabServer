using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("FK_Session_BelongToUser")]
        public UserItem User { get; set; }
  //      [Required]
  //      public int UserId { get; set; }
    }
}
