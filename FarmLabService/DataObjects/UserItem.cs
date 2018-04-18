using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmLabService.DataObjects
{
    public class UserItem
    {
        [Key] public string Email { get; set; }
    }
}
