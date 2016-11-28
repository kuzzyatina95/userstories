using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace user_stories.Models
{
    public class BusStop
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name of the bus stop")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int Status { get; set; }
    }
}