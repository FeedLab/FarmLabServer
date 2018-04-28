using System;
using System.ComponentModel.DataAnnotations;

namespace FarmLabService.DataObjects
{
    public class FarmItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid ExternalFarmReference { get; set; }
        [Required]
        public string DisplayName { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime TimeCreate { get; set; }
        [Required]
        public DateTime TimeModify { get; set; }
    }
}
