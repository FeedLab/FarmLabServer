﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FarmLabService.DataObjects
{
    public class UserItem
    {
        [Key]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public string Name { get; set; }

        public FarmItem Farm { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}
