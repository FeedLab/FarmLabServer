using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace FarmLabService.DataObjects
{
    public enum RoleType
    {
        FarmCreator = 101,
        Admin = 102,
        User = 103,
        ReadOnly = 104
    }

    public class UserItem
    {
        public UserItem()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsEnabled { get; set; }
        [Required]
        public bool IsConfirmedByMail { get; set; }
        [Required]
        public RoleType RoleType { get; set; }
        [Required]
        public DateTime TimeCreate { get; set; }
        [Required]
        public DateTime TimeModify{ get; set; }

        public FarmItem Farm { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public SessionItem ActiveSession { get; set; }
        public int SessionId { get; set; }
    }
}
