using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace user_stories.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Order")]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [Required]
        [Display(Name = "First and last name passenger")]
        public string PassengerFirstAndLastName { get; set; }

        [Required]
        [Display(Name = "Passenger document number")]
        public string PassengerDocumentNumber { get; set; }

        [Required]
        [Display(Name = "Passenger seat number")]
        public int PassengerSeatNumber { get; set; }

        [Required]
        [Display(Name = "Status")]
        public Status Status { get; set; }
    }
}