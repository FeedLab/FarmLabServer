using System;
using System.ComponentModel.DataAnnotations;

namespace FarmLabService.DataObjects
{
    public class FarmItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FarmName { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}
