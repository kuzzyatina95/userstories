using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace user_stories.Models
{
    public class Order
    {
        public int Id { get; set; }


        public int VoyageId { get; set; }
        [ForeignKey("VoyageId")]
        public VoyageData VoyageData { get; set; }

        [Display(Name = "Status")]
        public Status Status { get; set; }

    }
}